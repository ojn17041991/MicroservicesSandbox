using CentralService.Models.Responses.Abstract;
using System.Net;

namespace CentralService.Models.Responses
{
    public class HttpDataResponse<T> : IHttpDataResponse<T>
    {
        public HttpDataResponse(T entity, HttpStatusCode statusCode)
        {
            Entity = entity;
            StatusCode = statusCode;
        }



        public T Entity { get; }

        public HttpStatusCode StatusCode { get; }
    }
}
