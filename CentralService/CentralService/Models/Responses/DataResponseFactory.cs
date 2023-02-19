using CentralService.Models.Responses.Abstract;

namespace CentralService.Models.Responses
{
    public class DataResponseFactory : IDataResponseFactory
    {
        public IDataResponse<T> CreateResponse<T>(T entity)
        {
            return new DataResponse<T>(entity);
        }
    }
}
