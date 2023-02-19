using CentralService.DataProviders.Abstract;
using CentralService.Models.Baskets;
using CentralService.Models.Responses.Abstract;
using Newtonsoft.Json;
using System.Net;

namespace CentralService.DataProviders
{
    public class BasketProvider : IHttpDataProvider<Basket?>
    {
        IHttpDataResponseFactory dataResponseFactory;
        IHttpClientFactory httpClientFactory;
        ILogger<BasketProvider> logger;

        public string ServiceName { get; }

        public string EndPoint { get; }



        public BasketProvider(IHttpClientFactory httpClientFactory, ILogger<BasketProvider> logger, IHttpDataResponseFactory dataResponseFactory)
        {
            this.dataResponseFactory = dataResponseFactory;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            ServiceName = "basketService";
            EndPoint = "/api/basket/";
        }



        public async Task<IHttpDataResponse<Basket?>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IHttpDataResponse<Basket?>> GetAsync(int id)
        {
            Basket? basket = null;
            HttpStatusCode statusCode;

            try
            {
                using (HttpClient httpClient = httpClientFactory.CreateClient(ServiceName))
                {
                    HttpResponseMessage response = await httpClient.GetAsync(EndPoint + id);
                    statusCode = response.StatusCode;

                    string data = await response.Content.ReadAsStringAsync();
                    basket = JsonConvert.DeserializeObject<Basket?>(data);
                }
            }
            catch (Exception e)
            {
                statusCode = HttpStatusCode.InternalServerError;
                logger.LogError($"Failed HTTP Request to get Basket Contents for User ID {id} - {e}");
            }

            return dataResponseFactory.CreateResponse<Basket?>(basket, statusCode);
        }
    }
}
