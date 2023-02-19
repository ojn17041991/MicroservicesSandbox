using CentralService.Models.Responses.Abstract;

namespace CentralService.DataProviders.Abstract
{
    public interface IHttpDataProvider<T>
    {
        string ServiceName { get; }

        string EndPoint { get; }

        Task<IHttpDataResponse<T>> GetAsync();

        Task<IHttpDataResponse<T>> GetAsync(int id);
    }
}
