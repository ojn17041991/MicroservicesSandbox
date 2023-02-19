using CentralService.Models.Responses.Abstract;

namespace CentralService.Models.Responses
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public DataResponse(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
