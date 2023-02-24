using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace BasketService.DataAccess.Accessors.Abstract
{
    public interface IBasketItemAccessor : IDataPostable<BasketItem>, IDataDeletable<BasketItem>
    {
        IDataResponse<BasketItem> Get(int basketId, int itemId);

        IDataResponse<IEnumerable<BasketItem>> Get(int basketId);
    }
}
