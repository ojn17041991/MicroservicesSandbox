using MicroservicesSandbox.DataAccess.Abstract;
using MicroservicesSandbox.Enums;

namespace MicroservicesSandbox.DataAccess
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public DataResponse(T data, DataResponseType type)
        {
            Data = data;
            Type = type;
        }

        public T Data { get; }

        public DataResponseType Type { get; }
    }
}
