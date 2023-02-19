using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Response
{
    public class BasketItemResponse : IDataResponse<BasketItem>
    {
        public BasketItemResponse(BasketItem entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public BasketItem Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
