using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.ServiceAccess.Responses
{
    public class ItemResponse : IDataResponse<Item>
    {
        public ItemResponse(Item entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public Item Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
