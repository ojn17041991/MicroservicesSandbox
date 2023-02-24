using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Response
{
    public class BasketItemCollectionResponse : IDataResponse<IEnumerable<BasketItem>>
    {
        public BasketItemCollectionResponse(IEnumerable<BasketItem> entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public IEnumerable<BasketItem> Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
