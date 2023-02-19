using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataDeletable<T>
    {
        IDataResponse<T> Delete(T entity);
    }
}
