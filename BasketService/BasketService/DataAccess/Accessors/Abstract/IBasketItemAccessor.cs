using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;

namespace BasketService.DataAccess.Accessors.Abstract
{
    public interface IBasketItemAccessor : IDataPostable<BasketItem>, IDataDeletable<BasketItem>
    {

    }
}
