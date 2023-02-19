using MicroservicesSandbox.Enums;

namespace MicroservicesSandbox.DataAccess.Abstract
{
    public interface IDataResponse<T>
    {
        T Data { get; }

        DataResponseType Type { get; }
    }
}
