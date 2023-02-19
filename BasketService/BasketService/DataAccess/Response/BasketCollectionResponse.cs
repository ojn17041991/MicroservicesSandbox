using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Response
{
    public class BasketCollectionResponse : IDataResponse<IEnumerable<Basket>>
    {
        public BasketCollectionResponse(IEnumerable<Basket> entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public IEnumerable<Basket> Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
