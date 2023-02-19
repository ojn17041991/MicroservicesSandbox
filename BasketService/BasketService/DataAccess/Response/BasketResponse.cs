using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Response
{
    public class BasketResponse : IDataResponse<Basket>
    {
        public BasketResponse(Basket entity, DataResponseCode responseCode)
        {
            Entity = entity;
            ResponseCode = responseCode;
        }



        public Basket Entity { get; }

        public DataResponseCode ResponseCode { get; }
    }
}
