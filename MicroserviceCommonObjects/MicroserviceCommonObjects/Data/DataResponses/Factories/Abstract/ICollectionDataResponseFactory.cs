using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract
{
    public interface IDataCollectionResponseFactory<T>
    {
        IDataResponse<IEnumerable<T>> CreateCollectionResponse(IEnumerable<T> entity, DataResponseCode responseCode);
    }
}
