using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServiceSingleGettable<T>
    {
        Task<IDataResponse<T>> GetAsync(int id);
    }
}