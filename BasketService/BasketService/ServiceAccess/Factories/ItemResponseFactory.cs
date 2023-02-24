using BasketService.Model;
using BasketService.ServiceAccess.Responses;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.ServiceAccess.Factories
{
    public class ItemResponseFactory : ISingleDataResponseFactory<Item>
    {
        public IDataResponse<Item> CreateResponse(Item entity, DataResponseCode responseCode)
        {
            return new ItemResponse(entity, responseCode);
        }
    }
}
