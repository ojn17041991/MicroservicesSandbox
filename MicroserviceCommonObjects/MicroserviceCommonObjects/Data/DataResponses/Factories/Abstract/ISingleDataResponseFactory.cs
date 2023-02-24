using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract
{
    public interface ISingleDataResponseFactory<T>
    {
        IDataResponse<T> CreateResponse(T entity, DataResponseCode responseCode);
    }
}
