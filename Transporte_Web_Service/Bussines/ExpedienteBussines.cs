using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class ExpedienteBussines
    {
        private readonly ExpedienteDAL _dal;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public ExpedienteBussines(ExpedienteDAL dal, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _dal = dal;
            _configuration = configuration;
            _environment = environment;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_TipoDocumentoViaje_Guardar(Entity_TipoDocumentoViaje_Guardar entidad)
        {
            if (entidad.IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(entidad.Descripcion))
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La descripción es obligatoria.");
            }

            var respuesta = await _dal.Dal_TipoDocumentoViaje_Guardar(entidad);

            if (respuesta == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardó la información.");
            }

            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(respuesta);
        }

        public async Task<ApiResponse<IEnumerable<Entity_TipoDocumentoViaje_Listar?>>> Bs_TipoDocumentoViaje_Listar(int IdEmpresa, int? IdSucursal, bool SoloActivos, string? TipoEvento)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_TipoDocumentoViaje_Listar?>>.Fail("La empresa es obligatoria.");
            }

            var respuesta = await _dal.Dal_TipoDocumentoViaje_Listar(IdEmpresa, IdSucursal, SoloActivos, TipoEvento);

            if (respuesta == null)
            {
                return ApiResponse<IEnumerable<Entity_TipoDocumentoViaje_Listar?>>.Fail("No se encontró información.");
            }

            return ApiResponse<IEnumerable<Entity_TipoDocumentoViaje_Listar?>>.Success(respuesta);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_ViajeDocumento_Guardar(Entity_ViajeDocumento_Guardar entidad)
        {
            if (entidad.IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            if (entidad.IdViaje <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El viaje es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(entidad.NombreOriginal) || string.IsNullOrWhiteSpace(entidad.NombreArchivo) || string.IsNullOrWhiteSpace(entidad.RutaRelativa))
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El nombre y la ruta del archivo son obligatorios.");
            }

            var respuesta = await _dal.Dal_ViajeDocumento_Guardar(entidad);

            if (respuesta == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se guardó la información.");
            }

            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(respuesta);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_ViajeDocumento_Subir(Entity_ViajeDocumento_Subir entidad, IFormFile archivo)
        {
            if (entidad.IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            if (entidad.IdViaje <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El viaje es obligatorio.");
            }

            if (archivo == null || archivo.Length == 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El archivo es obligatorio.");
            }

            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            var extensionesPermitidas = new HashSet<string> { ".jpg", ".jpeg", ".png", ".webp", ".pdf", ".doc", ".docx", ".xls", ".xlsx" };

            if (!extensionesPermitidas.Contains(extension))
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El tipo de archivo no está permitido.");
            }

            var rutaBase = _configuration["ExpedienteArchivos:RutaBase"];
            if (string.IsNullOrWhiteSpace(rutaBase))
            {
                rutaBase = Path.Combine(_environment.ContentRootPath, "ArchivosExpediente");
            }

            var tipoEvento = string.IsNullOrWhiteSpace(entidad.TipoEvento) ? "General" : LimpiarSegmentoRuta(entidad.TipoEvento);
            var carpetaRelativa = Path.Combine("empresa-" + entidad.IdEmpresa, "viaje-" + entidad.IdViaje, tipoEvento);
            var carpetaFisica = Path.Combine(rutaBase, carpetaRelativa);
            Directory.CreateDirectory(carpetaFisica);

            var nombreOriginal = Path.GetFileName(archivo.FileName);
            var nombreArchivo = Guid.NewGuid().ToString("N") + extension;
            var rutaFisica = Path.Combine(carpetaFisica, nombreArchivo);

            using (var stream = new FileStream(rutaFisica, FileMode.CreateNew))
            {
                await archivo.CopyToAsync(stream);
            }

            var rutaRelativa = Path.Combine(carpetaRelativa, nombreArchivo).Replace("\\", "/");

            var documento = new Entity_ViajeDocumento_Guardar
            {
                IdEmpresa = entidad.IdEmpresa,
                IdSucursal = entidad.IdSucursal,
                IdViaje = entidad.IdViaje,
                IdEvento = entidad.IdEvento,
                IdViajeMovimiento = entidad.IdViajeMovimiento,
                IdTipoDocumentoViaje = entidad.IdTipoDocumentoViaje,
                IdUsuarioCarga = entidad.IdUsuarioCarga,
                TipoEvento = entidad.TipoEvento,
                NombreOriginal = nombreOriginal,
                NombreArchivo = nombreArchivo,
                Extension = extension,
                ContentType = archivo.ContentType,
                RutaRelativa = rutaRelativa,
                TamanoBytes = archivo.Length,
                Descripcion = entidad.Descripcion,
                FechaDocumento = entidad.FechaDocumento,
                Latitud = entidad.Latitud,
                Longitud = entidad.Longitud
            };

            return await Bs_ViajeDocumento_Guardar(documento);
        }

        public async Task<ApiResponse<IEnumerable<Entity_ViajeDocumento_Listar?>>> Bs_ViajeDocumento_ListarPorViaje(int IdViaje, int IdEmpresa, string? TipoEvento, bool SoloActivos)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_ViajeDocumento_Listar?>>.Fail("La empresa es obligatoria.");
            }

            if (IdViaje <= 0)
            {
                return ApiResponse<IEnumerable<Entity_ViajeDocumento_Listar?>>.Fail("El viaje es obligatorio.");
            }

            var respuesta = await _dal.Dal_ViajeDocumento_ListarPorViaje(IdViaje, IdEmpresa, TipoEvento, SoloActivos);

            if (respuesta == null)
            {
                return ApiResponse<IEnumerable<Entity_ViajeDocumento_Listar?>>.Fail("No se encontró información.");
            }

            return ApiResponse<IEnumerable<Entity_ViajeDocumento_Listar?>>.Success(respuesta);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_ViajeDocumento_Eliminar(int IdViajeDocumento, int IdEmpresa, int? IdUsuario)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            }

            if (IdViajeDocumento <= 0)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El documento es obligatorio.");
            }

            var respuesta = await _dal.Dal_ViajeDocumento_Eliminar(IdViajeDocumento, IdEmpresa, IdUsuario);

            if (respuesta == null)
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se eliminó la información.");
            }

            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(respuesta);
        }

        public async Task<ApiResponse<Entity_ViajeExpediente_Obtener>> Bs_ViajeExpediente_Obtener(int IdViaje, int IdEmpresa)
        {
            if (IdEmpresa <= 0)
            {
                return ApiResponse<Entity_ViajeExpediente_Obtener>.Fail("La empresa es obligatoria.");
            }

            if (IdViaje <= 0)
            {
                return ApiResponse<Entity_ViajeExpediente_Obtener>.Fail("El viaje es obligatorio.");
            }

            var respuesta = await _dal.Dal_ViajeExpediente_Obtener(IdViaje, IdEmpresa);

            if (respuesta == null)
            {
                return ApiResponse<Entity_ViajeExpediente_Obtener>.Fail("No se encontró información.");
            }

            return ApiResponse<Entity_ViajeExpediente_Obtener>.Success(respuesta);
        }

        private static string LimpiarSegmentoRuta(string valor)
        {
            foreach (var caracter in Path.GetInvalidFileNameChars())
            {
                valor = valor.Replace(caracter, '-');
            }

            return valor.Trim();
        }
    }
}


