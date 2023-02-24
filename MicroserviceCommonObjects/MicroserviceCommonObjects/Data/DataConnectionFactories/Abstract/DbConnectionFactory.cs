using System.Data.Common;

namespace MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract
{
    public abstract class DbConnectionFactory
    {
        public abstract string ConnectionString { get; }

        public abstract DbConnection CreateConnection();
    }
}
