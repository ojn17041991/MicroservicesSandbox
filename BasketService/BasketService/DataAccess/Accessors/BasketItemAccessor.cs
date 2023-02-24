using BasketService.DataAccess.Accessors.Abstract;
using BasketService.Model;
using BasketService.ServiceAccess.Accessors.Abstract;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace BasketService.DataAccess.Accessors
{
    public class BasketItemAccessor : IBasketItemAccessor
    {
        DbConnectionFactory connectionFactory;
        IDataResponseFactory<BasketItem> responseFactory;
        IItemServiceAccessor itemServiceAccessor;
        ILogger<BasketItemAccessor> logger;

        public BasketItemAccessor(
            DbConnectionFactory connection,
            IDataResponseFactory<BasketItem> responseFactory,
            IItemServiceAccessor itemServiceAccessor,
            ILogger<BasketItemAccessor> logger)
        {
            this.connectionFactory = connection;
            this.responseFactory = responseFactory;
            this.itemServiceAccessor = itemServiceAccessor;
            this.logger = logger;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public IDataResponse<BasketItem> Get(int basketId, int itemId)
        {
            BasketItem basketItem = new BasketItem();

            try
            {
                BasketItem? basketItemResponse = getBasketItem(basketId, itemId);

                if (basketItemResponse == null)
                {
                    return responseFactory.CreateResponse(basketItem, DataResponseCode.ResourceNotFound);
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to post basket item to database - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(basketItem, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(basketItem, DataResponseCode.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public IDataResponse<IEnumerable<BasketItem>> Get(int basketId)
        {
            IEnumerable<BasketItem> basketItems = Enumerable.Empty<BasketItem>();

            try
            {
                basketItems = getBasketItemsByBasketId(basketId);
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to post basket item to database - {Environment.NewLine}{e}");
                return responseFactory.CreateCollectionResponse(basketItems, DataResponseCode.Error);
            }

            return responseFactory.CreateCollectionResponse(basketItems, DataResponseCode.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IDataResponse<BasketItem> Post(BasketItem entity)
        {
            // Validate the request before we begin processing.
            DataResponseCode postValidated = validatePostRequest(entity);
            if (postValidated != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(entity, postValidated);
            }

            // Everything looks OK, so insert the record into the DB.
            try
            {
                using (DbConnection connection = connectionFactory.CreateConnection())
                {
                    connection.Open();

                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
INSERT INTO BasketItems (BasketID, ItemID)
VALUES (@BasketID, @ItemID)";

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
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to post basket item to database - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(entity, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(entity, DataResponseCode.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IDataResponse<BasketItem> Delete(BasketItem entity)
        {
            // Validate the request before we begin processing.
            DataResponseCode deleteValidated = validateDeleteRequest(entity);
            if (deleteValidated != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(entity, deleteValidated);
            }

            try
            {
                using (DbConnection connection = connectionFactory.CreateConnection())
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
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to delete basket item from database - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(entity, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(entity, DataResponseCode.OK);
        }



        private BasketItem? getBasketItem(int basketId, int itemId)
        {
            BasketItem? basketItem = null;

            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
SELECT * FROM BasketItems
WHERE BasketId = @BasketID
AND ItemID = @ItemID";

                    DbParameter basketIdParameter = command.CreateParameter();
                    basketIdParameter.ParameterName = "@BasketID";
                    basketIdParameter.Value = basketId;
                    command.Parameters.Add(basketIdParameter);

                    DbParameter itemIdParameter = command.CreateParameter();
                    itemIdParameter.ParameterName = "@ItemID";
                    itemIdParameter.Value = itemId;
                    command.Parameters.Add(itemIdParameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            basketItem = new BasketItem()
                            {
                                BasketId = Convert.ToInt32(reader["BasketID"]),
                                ItemId = Convert.ToInt32(reader["ItemID"])
                            };
                        }
                    }
                }
            }

            return basketItem;
        }

        private IEnumerable<BasketItem> getBasketItemsByBasketId(int basketId)
        {
            IList<BasketItem> basketItems = new List<BasketItem>();

            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                connection.Open();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
SELECT * FROM BasketItems
WHERE BasketId = @BasketID";

                    DbParameter basketIdParameter = command.CreateParameter();
                    basketIdParameter.ParameterName = "@BasketID";
                    basketIdParameter.Value = basketId;
                    command.Parameters.Add(basketIdParameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BasketItem basketItem = new BasketItem()
                            {
                                BasketId = Convert.ToInt32(reader["BasketID"]),
                                ItemId = Convert.ToInt32(reader["ItemID"])
                            };

                            basketItems.Add(basketItem);
                        }
                    }
                }
            }

            return basketItems;
        }

        private DataResponseCode validatePostRequest(BasketItem entity)
        {
            // Does the item already exist in the basket?
            IDataResponse<BasketItem> itemExistsInBasket = Get(entity.BasketId, entity.ItemId);
            if (itemExistsInBasket.ResponseCode == DataResponseCode.OK)
            {
                return DataResponseCode.ResourceDuplicated;
            }
            else if (itemExistsInBasket.ResponseCode == DataResponseCode.Error)
            {
                return DataResponseCode.Error;
            }

            // Does the item ID exist? Make a request to the item microservice.
            Task<IDataResponse<Item>> itemTask = itemServiceAccessor.GetAsync(entity.ItemId);
            IDataResponse<Item> itemResponse = itemTask.Result;
            if (itemResponse.ResponseCode != DataResponseCode.OK)
            {
                logger.LogWarning($"Item service could not find item {entity.ItemId}.");
                return itemResponse.ResponseCode;
            }

            return DataResponseCode.OK;
        }

        private DataResponseCode validateDeleteRequest(BasketItem entity)
        {
            // Does the item already exist in the basket?
            IDataResponse<BasketItem> itemExistsInBasket = Get(entity.BasketId, entity.ItemId);
            if (itemExistsInBasket.ResponseCode != DataResponseCode.OK)
            {
                return itemExistsInBasket.ResponseCode;
            }

            return DataResponseCode.OK;
        }
    }
}
