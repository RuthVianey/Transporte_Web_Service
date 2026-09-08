using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class SatCatalogosDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SatCatalogosDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Entity_SatCatalogoProdServ>> Dal_SatCatalogoProdServ_Listar(string? textoBusqueda, bool soloVigentes, int top)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_SatCatalogoProdServ>(
                "dbo.sp_SatCatalogoProdServ_Listar",
                new { TextoBusqueda = textoBusqueda, SoloVigentes = soloVigentes, Top = top },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_SatCatalogoRegimenFiscal>> Dal_SatCatalogoRegimenFiscal_Listar(string? textoBusqueda, byte? tipoPersona, int top)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_SatCatalogoRegimenFiscal>(
                "dbo.sp_SatCatalogoRegimenFiscal_Listar",
                new { TextoBusqueda = textoBusqueda, TipoPersona = tipoPersona, Top = top },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Entity_SatCatalogoUM>> Dal_SatCatalogoUM_Listar(string? textoBusqueda, int top)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_SatCatalogoUM>(
                "dbo.sp_SatCatalogoUM_Listar",
                new { TextoBusqueda = textoBusqueda, Top = top },
                commandType: CommandType.StoredProcedure);
        }
    }
}
