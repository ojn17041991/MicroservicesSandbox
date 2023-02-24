using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using Npgsql;
using System.Data.Common;

namespace MicroserviceCommonObjects.Data.DataConnectionFactories.Postgres
{
    public class NpgSqlConnectionFactory : DbConnectionFactory
    {
        public override string ConnectionString { get; } = string.Empty;

        public NpgSqlConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override DbConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
