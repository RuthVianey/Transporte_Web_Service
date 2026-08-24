using Transporte_Web_Service.Data;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Bussines
{
    public class UsuariosBS
    {
        private readonly UsuariosDAC _dac;

        public UsuariosBS(UsuariosDAC dac)
        {
            _dac = dac;
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Usuario_Guardar(int IdUsuario, int IdEmpresa, string Nombre, string Email, string Contrasenia, int? IdSucursal)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (string.IsNullOrWhiteSpace(Nombre)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(Email)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El email es obligatorio.");
            if (IdUsuario == 0 && string.IsNullOrWhiteSpace(Contrasenia)) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La contraseña es obligatoria para usuarios nuevos.");

            var resumen = await _dac.Usuario_Guardar(IdUsuario, IdEmpresa, Nombre, Email, Contrasenia, IdSucursal);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>> Usuario_Desactivar(int IdUsuario, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("La empresa es obligatoria.");
            if (IdUsuario <= 0) return ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("El usuario es obligatorio.");

            var resumen = await _dac.Usuario_Desactivar(IdUsuario, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_RespuestaGeneral?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Usuario_Listar?>>> Usuario_Listar(int IdEmpresa, byte SoloActivos, string? TextoBusqueda)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Fail("La empresa es obligatoria.");

            var resumen = await _dac.Usuario_Listar(IdEmpresa, SoloActivos, TextoBusqueda);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Success(resumen);
        }

        public async Task<ApiResponse<IEnumerable<Entity_Usuario_Listar?>>> Usuario_ObtenerPorId(int IdUsuario, int IdEmpresa)
        {
            if (IdEmpresa <= 0) return ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Fail("La empresa es obligatoria.");
            if (IdUsuario <= 0) return ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Fail("El usuario es obligatorio.");

            var resumen = await _dac.Usuario_ObtenerPorId(IdUsuario, IdEmpresa);
            return resumen == null
                ? ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Fail("No se encontró información.")
                : ApiResponse<IEnumerable<Entity_Usuario_Listar?>>.Success(resumen);
        }
    }
}