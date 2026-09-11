using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class ExpedienteDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ExpedienteDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_TipoDocumentoViaje_Guardar(Entity_TipoDocumentoViaje_Guardar entidad)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_TipoDocumentoViaje_Guardar",
                new
                {
                    entidad.IdTipoDocumentoViaje,
                    entidad.IdEmpresa,
                    entidad.IdSucursal,
                    entidad.Descripcion,
                    entidad.Clave,
                    entidad.AplicaCarga,
                    entidad.AplicaDescarga,
                    entidad.AplicaCierre,
                    entidad.Requerido,
                    entidad.Activo
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_TipoDocumentoViaje_Listar?>> Dal_TipoDocumentoViaje_Listar(int IdEmpresa, int? IdSucursal, bool SoloActivos, string? TipoEvento)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_TipoDocumentoViaje_Listar?>("dbo.sp_TipoDocumentoViaje_Listar",
                new
                {
                    IdEmpresa,
                    IdSucursal,
                    SoloActivos,
                    TipoEvento
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeDocumento_Guardar(Entity_ViajeDocumento_Guardar entidad)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeDocumento_Guardar",
                new
                {
                    entidad.IdViajeDocumento,
                    entidad.IdEmpresa,
                    entidad.IdSucursal,
                    entidad.IdViaje,
                    entidad.IdEvento,
                    entidad.IdViajeMovimiento,
                    entidad.IdTipoDocumentoViaje,
                    entidad.IdUsuarioCarga,
                    entidad.TipoEvento,
                    entidad.NombreOriginal,
                    entidad.NombreArchivo,
                    entidad.Extension,
                    entidad.ContentType,
                    entidad.RutaRelativa,
                    entidad.TamanoBytes,
                    entidad.Descripcion,
                    entidad.FechaDocumento,
                    entidad.Latitud,
                    entidad.Longitud
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_ViajeDocumento_Listar?>> Dal_ViajeDocumento_ListarPorViaje(int IdViaje, int IdEmpresa, string? TipoEvento, bool SoloActivos)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_ViajeDocumento_Listar?>("dbo.sp_ViajeDocumento_ListarPorViaje",
                new
                {
                    IdViaje,
                    IdEmpresa,
                    TipoEvento,
                    SoloActivos
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeDocumento_Eliminar(int IdViajeDocumento, int IdEmpresa, int? IdUsuario)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeDocumento_Eliminar",
                new
                {
                    IdViajeDocumento,
                    IdEmpresa,
                    IdUsuario
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Entity_ViajeExpediente_Obtener> Dal_ViajeExpediente_Obtener(int IdViaje, int IdEmpresa)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var resultado = await connection.QueryMultipleAsync("dbo.sp_ViajeExpediente_Obtener",
                new
                {
                    IdViaje,
                    IdEmpresa
                },
                commandType: CommandType.StoredProcedure);

            var viaje = await resultado.ReadAsync<dynamic>();
            var eventos = await resultado.ReadAsync<dynamic>();

            // Los movimientos activos son parte de la cronología del expediente.
            // Se conservan separados de los eventos manuales para no duplicarlos.
            var movimientos = await resultado.ReadAsync<dynamic>();
            var documentos = await resultado.ReadAsync<dynamic>();

            return new Entity_ViajeExpediente_Obtener
            {
                Viaje = viaje,
                Eventos = eventos,
                Movimientos = movimientos,
                Documentos = documentos
            };
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_EventoViaje_Guardar(Entity_EventoViaje_Guardar entidad)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_EventoViaje_Guardar", entidad, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_RespuestaGeneral?>> Dal_ViajeDocumento_Revisar(Entity_ViajeDocumento_Revisar entidad)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Entity_RespuestaGeneral?>("dbo.sp_ViajeDocumento_Revisar", entidad, commandType: CommandType.StoredProcedure);
        }
    }
}

