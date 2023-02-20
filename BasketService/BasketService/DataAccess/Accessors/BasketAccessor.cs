using BasketService.DataAccess.Accessors.Abstract;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace BasketService.DataAccess.Accessors
{
    public class BasketAccessor : IBasketAccessor
    {
        DbConnection connection;
        IDataResponseFactory<Basket> responseFactory;
        ILogger<BasketAccessor> logger;

        public BasketAccessor(DbConnection connection, IDataResponseFactory<Basket> responseFactory, ILogger<BasketAccessor> logger)
        {
            this.connection = connection;
            this.responseFactory = responseFactory;
            this.logger = logger;
        }

        public IDataResponse<Basket> Get(int basketId)
        {
            Basket basket = new Basket();

            try
            {
                connection.Open();

                Basket? basketResponse = getBasket(basketId);

                if (basketResponse == null)
                {
                    return responseFactory.CreateResponse(basket, DataResponseCode.ResourceNotFound);
                }

                IList<BasketItem> basketItemsResponse = getBasketItems(basketResponse.Id);

                basketResponse.Items = basketItemsResponse;
                basket = basketResponse;

                connection.Close();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get basket from database for ID {basketId} - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(basket, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(basket, DataResponseCode.OK);
        }

        private Basket? getBasket(int basketId)
        {
            Basket? basket = null;

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT * FROM Baskets
WHERE ID = @BasketID";

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@BasketID";
                parameter.Value = basketId;
                command.Parameters.Add(parameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        basket = new Basket()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Items = new List<BasketItem>()
                        };

                        break;
                    }
                }
            }

            return basket;
        }

        private IList<BasketItem> getBasketItems(int basketId)
        {
            IList<BasketItem> basketItems = new List<BasketItem>();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT * FROM BasketItems
WHERE BasketID = @BasketID";

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@BasketID";
                parameter.Value = basketId;
                command.Parameters.Add(parameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BasketItem basketItem = new BasketItem()
                        {
                            BasketId = Convert.ToInt32(reader["BasketID"]),
                            ItemId = Convert.ToInt32(reader["ItemID"]),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                        basketItems.Add(basketItem);
                    }
                }
            }

            return basketItems;
        }
    }
}





//public IDataResponse<Basket> GetByUserId(int userId)
//{
//    Basket basket = new Basket();

//    try
//    {
//        connection.Open();

//        Basket? basketResponse = getBasket(userId);

//        if (basketResponse == null)
//        {
//            return responseFactory.CreateResponse(basket, DataResponseCode.ResourceNotFound);
//        }

//        IList<BasketItem> basketItemsResponse = getBasketItems(basketResponse.BasketId);

//        basketResponse.Items = basketItemsResponse;
//        basket = basketResponse;

//        connection.Close();
//    }
//    catch (Exception e)
//    {
//        logger.LogError($"Failed to get basket from database for user ID {userId} - {Environment.NewLine}{e}");
//        return responseFactory.CreateResponse(basket, DataResponseCode.Error);
//    }

//    return responseFactory.CreateResponse(basket, DataResponseCode.OK);
//}

//        private Basket? getBasket(int userId)
//        {
//            Basket? basket = null;

//            using (DbCommand command = connection.CreateCommand())
//            {
//                command.CommandText = @"
//SELECT * FROM Baskets
//WHERE UserID = @UserID";

//                DbParameter parameter = command.CreateParameter();
//                parameter.ParameterName = "@UserID";
//                parameter.Value = userId;
//                command.Parameters.Add(parameter);

//                using (DbDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        basket = new Basket()
//                        {
//                            BasketId = Convert.ToInt32(reader["BasketID"]),
//                            UserId = Convert.ToInt32(reader["UserID"]),
//                            Items = new List<BasketItem>()
//                        };

//                        break;
//                    }
//                }
//            }

//            return basket;
//        }