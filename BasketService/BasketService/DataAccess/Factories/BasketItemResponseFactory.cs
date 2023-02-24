using BasketService.DataAccess.Response;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Factories
{
    public class BasketItemResponseFactory : IDataResponseFactory<BasketItem>
    {
        public IDataResponse<BasketItem> CreateResponse(BasketItem entity, DataResponseCode responseCode)
        {
            return new BasketItemResponse(entity, responseCode);
        }

        public IDataResponse<IEnumerable<BasketItem>> CreateCollectionResponse(IEnumerable<BasketItem> entity, DataResponseCode responseCode)
        {
            return new BasketItemCollectionResponse(entity, responseCode);
        }
    }
}
