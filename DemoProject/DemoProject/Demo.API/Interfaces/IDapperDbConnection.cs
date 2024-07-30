using System.Data;

namespace Demo.API.Interfaces
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
}
