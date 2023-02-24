using BasketService.Model;
using MicroserviceCommonObjects.Services.ServiceAccessors.Abstract;

namespace BasketService.ServiceAccess.Accessors.Abstract
{
    public interface IItemServiceAccessor : IServiceSingleGettable<Item>, IService
    {

    }
}