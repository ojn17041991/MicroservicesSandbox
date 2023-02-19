using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServiceDeletable<T>
    {
        Task<IDataResponse<T>> DeleteAsync(T entity);
    }
}