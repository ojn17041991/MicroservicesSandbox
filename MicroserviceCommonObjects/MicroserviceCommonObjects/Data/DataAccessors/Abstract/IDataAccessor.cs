using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataAccessor<T>
    {
        IDataResponse<IEnumerable<T>> Get();

        IDataResponse<T> Get(int id);

        IDataResponse<T> Post(T entity);

        IDataResponse<T> Put(T entity);

        IDataResponse<T> Patch(T entity);

        IDataResponse<T> Delete(T entity);
    }
}
