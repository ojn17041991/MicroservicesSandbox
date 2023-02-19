using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServicePostable<T>
    {
        Task<IDataResponse<T>> PostAsync(T entity);
    }
}