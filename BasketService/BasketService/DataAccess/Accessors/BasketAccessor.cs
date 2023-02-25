using BasketService.DataAccess.Accessors.Abstract;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataConnectionFactories.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace BasketService.DataAccess.Accessors
{
    public class BasketAccessor : IBasketAccessor
    {
        DbConnectionFactory connectionFactory;
        ISingleDataResponseFactory<Basket> responseFactory;
        IBasketItemAccessor basketItemAccessor;
        ILogger<BasketAccessor> logger;

        public BasketAccessor(
            DbConnectionFactory connection,
            ISingleDataResponseFactory<Basket> responseFactory,
            IBasketItemAccessor basketItemAccessor,
            ILogger<BasketAccessor> logger)
        {
            this.connectionFactory = connection;
            this.responseFactory = responseFactory;
            this.basketItemAccessor = basketItemAccessor;
            this.logger = logger;
        }



        public IDataResponse<Basket> Get(int basketId)
        {
            Basket basket = new Basket();

            try
            {
                Basket? basketResponse = getBasket(basketId);

                if (basketResponse == null)
                {
                    return responseFactory.CreateResponse(basket, DataResponseCode.ResourceNotFound);
                }

                IDataResponse<IEnumerable<BasketItem>> basketItemsResponse = basketItemAccessor.Get(basketResponse.Id);

                if (basketItemsResponse.ResponseCode != DataResponseCode.OK)
                {
                    return responseFactory.CreateResponse(basket, basketItemsResponse.ResponseCode);
                }

                basketResponse.Items = basketItemsResponse.Entity;
                basket = basketResponse;
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get basket from database for ID {basketId} - {Environment.NewLine}{e}");
                return responseFactory.CreateResponse(basket, DataResponseCode.Error);
            }

            return responseFactory.CreateResponse(basket, DataResponseCode.OK);
        }

        public IDataResponse<Basket> Post()
        {
            throw new NotImplementedException();
        }

        public IDataResponse<Basket> PostBasketItem(BasketItem basketItem)
        {
            Basket basket = new Basket();

            DataResponseCode basketExists = validateItemWrite(basketItem);
            if (basketExists != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketExists);
            }

            IDataResponse<BasketItem> basketItemResponse = basketItemAccessor.Post(basketItem);
            if (basketItemResponse.ResponseCode != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketItemResponse.ResponseCode);
            }

            IDataResponse<Basket> basketResponse = Get(basketItem.BasketId);
            if (basketResponse.ResponseCode != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketResponse.ResponseCode);
            }

            basket = basketResponse.Entity;

            return responseFactory.CreateResponse(basket, DataResponseCode.OK);
        }

        public IDataResponse<Basket> DeleteBasketItem(BasketItem basketItem)
        {
            Basket basket = new Basket();

            DataResponseCode basketExists = validateItemWrite(basketItem);
            if (basketExists != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketExists);
            }

            IDataResponse<BasketItem> basketItemResponse = basketItemAccessor.Delete(basketItem);
            if (basketItemResponse.ResponseCode != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketItemResponse.ResponseCode);
            }

            IDataResponse<Basket> basketResponse = Get(basketItem.BasketId);
            if (basketResponse.ResponseCode != DataResponseCode.OK)
            {
                return responseFactory.CreateResponse(basket, basketResponse.ResponseCode);
            }

            basket = basketResponse.Entity;

            return responseFactory.CreateResponse(basket, DataResponseCode.OK);
        }



        private Basket? getBasket(int basketId)
        {
            Basket? basket = null;

            using (DbConnection connection = connectionFactory.CreateConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = @"
SELECT * FROM Baskets
WHERE ID = @BasketID";

                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = "@BasketID";
                    parameter.Value = basketId;
                    command.Parameters.Add(parameter);

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            basket = new Basket()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Items = new List<BasketItem>()
                            };
                        }
                    }
                }
            }

            return basket;
        }

        private DataResponseCode validateItemWrite(BasketItem basketItem)
        {
            Basket? basket = getBasket(basketItem.BasketId);
            if (basket == null)
            {
                return DataResponseCode.ResourceNotFound;
            }

            return DataResponseCode.OK;
        }
    }
}