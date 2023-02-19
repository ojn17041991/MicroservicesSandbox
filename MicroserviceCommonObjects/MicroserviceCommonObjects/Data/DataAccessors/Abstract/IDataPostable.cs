using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataPostable<T>
    {
        IDataResponse<T> Post(T entity);
    }
}
