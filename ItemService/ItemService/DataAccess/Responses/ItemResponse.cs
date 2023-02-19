using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;

namespace ItemService.DataAccess.Responses
{
    public class ItemResponse : IDataResponse<Item>
    {
        public Item Entity => throw new NotImplementedException();

        public DataResponseCode ResponseCode => throw new NotImplementedException();
    }
}
