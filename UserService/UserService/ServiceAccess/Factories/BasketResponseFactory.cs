using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using UserService.Models;
using UserService.ServiceAccess.Responses;

namespace UserService.ServiceAccess.Factories
{
    public class BasketResponseFactory : ISingleDataResponseFactory<Basket>
    {
        public IDataResponse<Basket> CreateResponse(Basket entity, DataResponseCode responseCode)
        {
            return new BasketResponse(entity, responseCode);
        }
    }
}
