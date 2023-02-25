using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using System.Net;
using UserService.Models;
using UserService.ServiceAccess.Accessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using Newtonsoft.Json;

namespace UserService.ServiceAccess.Accessors
{
    public class BasketServiceAccessor : IBasketServiceAccessor
    {
        ISingleDataResponseFactory<Basket> responseFactory;
        IHttpClientFactory httpClientFactory;
        ILogger<BasketServiceAccessor> logger;

        public BasketServiceAccessor(
            ISingleDataResponseFactory<Basket> responseFactory,
            IHttpClientFactory httpClientFactory,
            ILogger<BasketServiceAccessor> logger)
        {
            this.responseFactory = responseFactory;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            ServiceName = "basketService";
            BaseAddress = "https://localhost:7101";
            EndPoint = "/api/basket/";
        }

        public string ServiceName { get; }

        public string BaseAddress { get; }

        public string EndPoint { get; }

        public async Task<IDataResponse<Basket>> PostAsync()
        {
            Basket basket = new Basket();
            DataResponseCode responseCode;

            try
            {
                using (HttpClient httpClient = httpClientFactory.CreateClient(ServiceName))
                {
                    httpClient.BaseAddress = new Uri(BaseAddress);

                    // There's nothing to actually POST. I just need it to create a Basket and return the ID.
                    HttpResponseMessage response = await httpClient.PostAsync(EndPoint, new StringContent(string.Empty));

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        basket = JsonConvert.DeserializeObject<Basket?>(data) ?? new Basket();
                        responseCode = DataResponseCode.OK;
                    }
                    else
                    {
                        responseCode = DataResponseCode.Error;
                    }
                }
            }
            catch (Exception e)
            {
                responseCode = DataResponseCode.Error;
                logger.LogError($"Failed to post to Basket Service - {e}");
            }

            return responseFactory.CreateResponse(basket, responseCode);
        }
    }
}
