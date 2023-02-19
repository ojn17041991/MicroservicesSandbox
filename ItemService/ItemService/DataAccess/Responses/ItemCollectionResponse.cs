using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace ItemService.DataAccess.Responses
{
    public class ItemCollectionResponse : IDataResponse<IEnumerable<Item>>
    {
        public IEnumerable<Item> Entity => throw new NotImplementedException();

        public DataResponseCode ResponseCode => throw new NotImplementedException();
    }
}
