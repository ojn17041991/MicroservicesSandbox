using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServicePatchable<T>
    {
        Task<IDataResponse<T>> PatchAsync(T entity);
    }
}