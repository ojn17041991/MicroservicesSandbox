using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;

namespace BasketService.DataAccess.Accessors.Abstract
{
    public interface IBasketAccessor : IDataSingleGettable<Basket>
    {
        //IDataResponse<Basket> GetByUserId(int userId);
    }
}
