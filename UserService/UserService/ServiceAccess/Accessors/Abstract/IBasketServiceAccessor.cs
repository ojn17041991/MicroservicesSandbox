using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Services.ServiceAccessors.Abstract;
using UserService.Models;

namespace UserService.ServiceAccess.Accessors.Abstract
{
    public interface IBasketServiceAccessor : IService
    {
        Task<IDataResponse<Basket>> PostAsync();
    }
}
