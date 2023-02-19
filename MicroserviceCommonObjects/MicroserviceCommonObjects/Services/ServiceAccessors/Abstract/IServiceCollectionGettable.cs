using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace MicroserviceCommonObjects.Services.ServiceAccessors.Abstract
{
    public interface IServiceCollectionGettable<T>
    {
        Task<IDataResponse<IEnumerable<T>>> GetAsync();
    }
}