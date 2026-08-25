using Dapper;
using System.Data;
using Transporte_Web_Service.Data.Database;
using Transporte_Web_Service.Entity;

namespace Transporte_Web_Service.Data
{
    public class CatalogoDomicilioDAL
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CatalogoDomicilioDAL(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Entity_Catalogo_Domicilio?>> Dal_Catalogo_Domicilio_Listar(string codigoPostal, string asentamiento, string estado, string municipio)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<Entity_Catalogo_Domicilio?>("dbo.sp_Catalogo_Domicilio",
                new
                {
                    Codigo_Postal = codigoPostal,
                    Asentamiento = asentamiento,
                    Estado = estado,
                    Municipio = municipio
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
