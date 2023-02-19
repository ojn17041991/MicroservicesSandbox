using CentralService.Models.Responses.Abstract;
using System.Net;

namespace CentralService.Models.Responses
{
    public class HttpDataResponseFactory : IHttpDataResponseFactory
    {
        public IDataResponse<T> CreateResponse<T>(T entity)
        {
            return new DataResponse<T>(entity);
        }

        public IHttpDataResponse<T> CreateResponse<T>(T entity, HttpStatusCode statusCode)
        {
            return new HttpDataResponse<T>(entity, statusCode);
        }
    }
}
