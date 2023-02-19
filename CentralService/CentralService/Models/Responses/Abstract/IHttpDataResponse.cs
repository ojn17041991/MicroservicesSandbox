using System.Net;

namespace CentralService.Models.Responses.Abstract
{
    public interface IHttpDataResponse<T> : IDataResponse<T>
    {
        HttpStatusCode StatusCode { get; }
    }
}
