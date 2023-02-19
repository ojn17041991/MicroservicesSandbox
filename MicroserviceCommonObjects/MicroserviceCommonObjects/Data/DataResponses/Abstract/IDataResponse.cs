using MicroserviceCommonObjects.Enums;

namespace MicroserviceCommonObjects.Data.DataResponses.Abstract
{
    public interface IDataResponse<T>
    {
        T Entity { get; }

        DataResponseCode ResponseCode { get; }
    }
}
