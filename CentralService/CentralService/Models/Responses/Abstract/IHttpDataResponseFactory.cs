using System.Net;

namespace CentralService.Models.Responses.Abstract
{
    public interface IHttpDataResponseFactory
    {
        IHttpDataResponse<T> CreateResponse<T>(T entity, HttpStatusCode statusCode);
    }
}
