using ItemService.DataAccess.Accessors.Abstract;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using System.Data.Common;

namespace ItemService.DataAccess.Accessors
{
    public class ItemAccessor : IItemAccessor
    {
        DbConnection connection;
        IDataResponseFactory<Item> responseFactory;
        ILogger<ItemAccessor> logger;

        public ItemAccessor(DbConnection connection, IDataResponseFactory<Item> responseFactory, ILogger<ItemAccessor> logger)
        {
            this.connection = connection;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<Item> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<IEnumerable<Item>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
