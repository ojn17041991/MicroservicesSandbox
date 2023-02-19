using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServiceAccessor<T> : IDataAccessor<T>
    {
        string ServiceName { get; }

        string EndPoint { get; }

        Task<IDataResponse<IEnumerable<T>>> GetAsync();

        Task<IDataResponse<T>> GetAsync(int id);

        Task<IDataResponse<T>> PostAsync(T entity);

        Task<IDataResponse<T>> PutAsync(T entity);

        Task<IDataResponse<T>> PatchAsync(T entity);

        Task<IDataResponse<T>> DeleteAsync(T entity);
    }
}