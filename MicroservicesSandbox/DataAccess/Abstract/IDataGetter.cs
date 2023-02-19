namespace MicroservicesSandbox.DataAccess.Abstract
{
    public interface IDataGetter<T>
    {
        IDataResponse<T> Get();

        IDataResponse<IEnumerable<T>> Get(T entity);
    }
}
