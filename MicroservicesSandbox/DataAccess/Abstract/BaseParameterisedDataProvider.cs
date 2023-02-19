using System.Data.Common;

namespace MicroservicesSandbox.DataAccess.Abstract
{
    public abstract class BaseParameterisedDataProvider<T> : IDataProvider<T>
    {
        public abstract IDataResponse<T> Add(T value);

        public abstract IDataResponse<T> Delete(T value);

        public abstract IDataResponse<T> Get();

        public abstract IDataResponse<IEnumerable<T>> Get(T entity);

        public abstract IDataResponse<T> Set(T value);

        protected DbParameter GenerateParameter(DbCommand command, string name, object value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
            return parameter;
        }
    }
}
