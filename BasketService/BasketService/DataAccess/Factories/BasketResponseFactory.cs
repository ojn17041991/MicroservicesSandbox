using BasketService.DataAccess.Response;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;

namespace BasketService.DataAccess.Factories
{
    public class BasketResponseFactory : IDataResponseFactory<Basket>
    {
        public IDataResponse<Basket> CreateResponse(Basket entity, DataResponseCode responseCode)
        {
            return new BasketResponse(entity, responseCode);
        }
    }
}
