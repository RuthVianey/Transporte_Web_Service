using System.Data;

namespace Transporte_Web_Service.Data.Database
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }


}
