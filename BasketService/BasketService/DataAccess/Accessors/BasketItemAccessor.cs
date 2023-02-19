using BasketService.DataAccess.Accessors.Abstract;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace BasketService.DataAccess.Accessors
{
    public class BasketItemAccessor : IBasketItemAccessor
    {
        DbConnection connection;
        IDataResponseFactory<BasketItem> responseFactory;
        ILogger<BasketItemAccessor> logger;

        public BasketItemAccessor(DbConnection connection, IDataResponseFactory<BasketItem> responseFactory, ILogger<BasketItemAccessor> logger)
        {
            this.connection = connection;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<BasketItem> Post(BasketItem entity)
        {
            // OJN: Check basket exists here first.
            // OJN: Check the item ID given is valid.

            try
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
INSERT INTO BasketItems (BasketID, ItemID, Quantity)
VALUES (@BasketID, @ItemID, @Quantity)";

                    DbParameter basketIdParameter = command.CreateParameter();
                    basketIdParameter.ParameterName = "@BasketID";
                    basketIdParameter.Value = entity.BasketId;
                    command.Parameters.Add(basketIdParameter);

                    DbParameter itemIdParameter = command.CreateParameter();
                    itemIdParameter.ParameterName = "@ItemID";
                    itemIdParameter.Value = entity.ItemId;
                    command.Parameters.Add(itemIdParameter);

                    DbParameter quantityParameter = command.CreateParameter();
                    quantityParameter.ParameterName = "@Quantity";
                    quantityParameter.Value = entity.Quantity;
                    command.Parameters.Add(quantityParameter);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to post basket item to database - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(entity, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(entity, DataResponseCode.OK);
        }

        public IDataResponse<BasketItem> Delete(BasketItem entity)
        {
            // OJN: Check basket exists here first.
            // OJN: Check item exists in basket.

            try
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
DELETE FROM BasketItems
WHERE BasketID = @BasketID AND ItemID = @ItemID";

                    DbParameter basketIdParameter = command.CreateParameter();
                    basketIdParameter.ParameterName = "@BasketID";
                    basketIdParameter.Value = entity.BasketId;
                    command.Parameters.Add(basketIdParameter);

                    DbParameter itemIdParameter = command.CreateParameter();
                    itemIdParameter.ParameterName = "@ItemID";
                    itemIdParameter.Value = entity.ItemId;
                    command.Parameters.Add(itemIdParameter);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to delete basket item from database - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(entity, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(entity, DataResponseCode.OK);
        }
    }
}
