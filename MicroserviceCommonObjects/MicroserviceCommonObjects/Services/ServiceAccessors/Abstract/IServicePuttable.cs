using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServicePuttable<T>
    {
        Task<IDataResponse<T>> PutAsync(T entity);
    }
}