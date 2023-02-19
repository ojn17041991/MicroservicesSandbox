using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Data.DataAccessors.Abstract
{
    public interface IDataCollectionGettable<T>
    {
        IDataResponse<IEnumerable<T>> Get();
    }
}
