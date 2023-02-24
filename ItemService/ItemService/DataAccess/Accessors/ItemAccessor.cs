using ItemService.DataAccess.Accessors.Abstract;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace ItemService.DataAccess.Accessors
{
    public class ItemAccessor : IItemAccessor
    {
        DbConnectionFactory connectionFactory;
        ISingleDataResponseFactory<Item> responseFactory;
        ILogger<ItemAccessor> logger;

        public ItemAccessor(
            DbConnectionFactory connectionFactory,
            ISingleDataResponseFactory<Item> responseFactory,
            ILogger<ItemAccessor> logger)
        {
            this.connectionFactory = connectionFactory;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<Item> Get(int id)
        {
            Item item = new Item();
            bool itemFound = false;

            try
            {
                using (DbConnection connection = connectionFactory.CreateConnection())
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
                }
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
