using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.Models;

namespace UserService.ServiceAccess.Responses
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
