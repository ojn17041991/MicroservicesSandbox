using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Data.Common;

namespace BasketService.DataAccess
{
    public class BasketAccessor : IDataAccessor<Basket>
    {
        DbConnection connection;
        IDataResponseFactory<Basket> responseFactory;

        public BasketAccessor(DbConnection connection, IDataResponseFactory<Basket> responseFactory)
        {
            this.connection = connection;
            this.responseFactory = responseFactory;
        }

        public IDataResponse<IEnumerable<Basket>> Get()
        {
            return responseFactory.CreateResponse(Enumerable.Empty<Basket>(), DataResponseCode.ResourceNotFound);
        }

        public IDataResponse<Basket> Get(int userId)
        {
            Basket basket = new Basket();

            connection.Open();

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
SELECT ProductID, Name AS ProductName, Description AS ProductDescription, Quantity FROM basket
INNER JOIN product
ON basket.productID = product.ID
WHERE UserID = @UserID";

                DbParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@UserID";
                parameter.Value = userId;
                command.Parameters.Add(parameter);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BasketItem item = new BasketItem()
                        {
                            ProductId = Convert.ToInt32(reader["ProductID"]),
                            ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                            ProductDescription = reader["ProductDescription"]?.ToString() ?? string.Empty,
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                        basket.Items.Add(item);
                    }
                }
            }

            connection.Close();

            return responseFactory.CreateResponse(basket, DataResponseCode.OK);
        }

        public IDataResponse<Basket> Post(Basket entity)
        {
            return responseFactory.CreateResponse(new Basket(), DataResponseCode.ResourceNotFound);
        }

        public IDataResponse<Basket> Put(Basket entity)
        {
            return responseFactory.CreateResponse(new Basket(), DataResponseCode.ResourceNotFound);
        }

        public IDataResponse<Basket> Patch(Basket entity)
        {
            return responseFactory.CreateResponse(new Basket(), DataResponseCode.ResourceNotFound);
        }

        public IDataResponse<Basket> Delete(Basket entity)
        {
            return responseFactory.CreateResponse(new Basket(), DataResponseCode.ResourceNotFound);
        }
    }
}
