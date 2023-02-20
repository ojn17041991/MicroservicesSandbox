using ItemService.DataAccess.Accessors.Abstract;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
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
            Item item = new Item();
            bool itemFound = false;

            try
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
SELECT * FROM Items
WHERE ID = @ItemID";

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@ItemID";
                    parameter.Value = id;
                    command.Parameters.Add(parameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemFound = true;

                            item = new Item()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString() ?? string.Empty
                            };

                            break;
                        }
                    }
                }

                connection.Close();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get user from database for ID {id} - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(item, DataResponseCode.Error);
            }

            if (itemFound)
            {
                return responseFactory.CreateResponse(item, DataResponseCode.OK);
            }
            else
            {
                return responseFactory.CreateResponse(item, DataResponseCode.ResourceNotFound);
            }
        }
    }
}
