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

            if ((entidad.Latitud.HasValue && !entidad.Longitud.HasValue)
                || (!entidad.Latitud.HasValue && entidad.Longitud.HasValue)
                || (entidad.Latitud.HasValue && (entidad.Latitud < -90 || entidad.Latitud > 90))
                || (entidad.Longitud.HasValue && (entidad.Longitud < -180 || entidad.Longitud > 180)))
            {
                return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La ubicación geográfica no es válida.");
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

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_EventoViaje_Guardar(Entity_EventoViaje_Guardar entidad)
        {
            if (entidad.IdEmpresa <= 0 || entidad.IdViaje <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Empresa y viaje son obligatorios.");
            if (!new[] { "CARGA", "DESCARGA", "CIERRE", "GENERAL" }.Contains((entidad.TipoEvento ?? string.Empty).Trim().ToUpperInvariant())) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El tipo de evento no es válido.");
            var respuesta = await _dal.Dal_EventoViaje_Guardar(entidad);
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(respuesta);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Bs_ViajeDocumento_Revisar(Entity_ViajeDocumento_Revisar entidad)
        {
            if (entidad.IdEmpresa <= 0 || entidad.IdViajeDocumento <= 0 || entidad.IdUsuarioRevisor <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Empresa, documento y revisor son obligatorios.");
            if (!new[] { "APROBADO", "RECHAZADO" }.Contains((entidad.EstadoRevision ?? string.Empty).Trim().ToUpperInvariant())) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La decisión de revisión no es válida.");
            if (entidad.EstadoRevision.Trim().Equals("RECHAZADO", StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(entidad.ComentarioRevision)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("Indica el motivo del rechazo.");
            var respuesta = await _dal.Dal_ViajeDocumento_Revisar(entidad);
            return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(respuesta);
        }

        public async Task<ApiResponse<Entity_ArchivoExpediente>> Bs_ViajeDocumento_ObtenerArchivo(int IdViajeDocumento, int IdViaje, int IdEmpresa)
        {
            if (IdEmpresa <= 0 || IdViaje <= 0 || IdViajeDocumento <= 0)
            {
                return ApiResponse<Entity_ArchivoExpediente>.Fail("Empresa, viaje y documento son obligatorios.");
            }

            var documentos = await _dal.Dal_ViajeDocumento_ListarPorViaje(IdViaje, IdEmpresa, null, true);
            var documento = documentos?.FirstOrDefault(item => item?.IdViajeDocumento == IdViajeDocumento);
            if (documento == null)
            {
                return ApiResponse<Entity_ArchivoExpediente>.Fail("No se encontró el documento.");
            }

            var rutaBase = _configuration["ExpedienteArchivos:RutaBase"];
            if (string.IsNullOrWhiteSpace(rutaBase))
            {
                rutaBase = Path.Combine(_environment.ContentRootPath, "ArchivosExpediente");
            }

            var baseCompleta = Path.GetFullPath(rutaBase);
            var rutaCompleta = Path.GetFullPath(Path.Combine(baseCompleta, documento.RutaRelativa));
            if (!rutaCompleta.StartsWith(baseCompleta + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase)
                || !File.Exists(rutaCompleta))
            {
                return ApiResponse<Entity_ArchivoExpediente>.Fail("El archivo no se encuentra en el servidor.");
            }

            return ApiResponse<Entity_ArchivoExpediente>.Success(new Entity_ArchivoExpediente
            {
                RutaFisica = rutaCompleta,
                NombreDescarga = documento.NombreOriginal,
                ContentType = string.IsNullOrWhiteSpace(documento.ContentType)
                    ? "application/octet-stream"
                    : documento.ContentType
            });
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


