using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;

namespace ItemService.DataAccess.Factories
{
    public class ItemResponseFactory : IDataResponseFactory<Item>
    {
        public IDataResponse<Item> CreateResponse(Item entity, DataResponseCode responseCode)
        {
            throw new NotImplementedException();
        }
    }
}
