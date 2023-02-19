using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataPuttable<T>
    {
        IDataResponse<T> Put(T entity);
    }
}
