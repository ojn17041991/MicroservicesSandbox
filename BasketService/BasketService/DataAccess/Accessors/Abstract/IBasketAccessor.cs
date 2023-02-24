using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;

namespace BasketService.DataAccess.Accessors.Abstract
{
    public interface IBasketAccessor : IDataSingleGettable<Basket>
    {
        IDataResponse<Basket> PostBasketItem(BasketItem basketItem);

        IDataResponse<Basket> DeleteBasketItem(BasketItem basketItem);
    }
}
