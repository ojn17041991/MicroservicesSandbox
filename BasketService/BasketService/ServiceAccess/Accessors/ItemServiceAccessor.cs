using BasketService.Model;
using BasketService.ServiceAccess.Accessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Factories.Abstract;
using MicroserviceCommonObjects.Enums;
using Newtonsoft.Json;
using System.Net;

namespace BasketService.ServiceAccess.Accessors
{
    public class ItemServiceAccessor : IItemServiceAccessor
    {
        ISingleDataResponseFactory<Item> responseFactory;
        IHttpClientFactory httpClientFactory;
        ILogger<ItemServiceAccessor> logger;

        public ItemServiceAccessor(
            ISingleDataResponseFactory<Item> responseFactory,
            IHttpClientFactory httpClientFactory,
            ILogger<ItemServiceAccessor> logger)
        {
            this.responseFactory = responseFactory;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            ServiceName = "itemService";
            BaseAddress = "https://localhost:7089";
            EndPoint = "/api/item/";
        }



        public string ServiceName { get; }

        public string BaseAddress { get; }

        public string EndPoint { get; }

        public async Task<IDataResponse<Item>> GetAsync(int id)
        {
            Item item = new Item();
            DataResponseCode responseCode;

            try
            {
                using (HttpClient httpClient = httpClientFactory.CreateClient(ServiceName))
                {
                    httpClient.BaseAddress = new Uri(BaseAddress);

                    HttpResponseMessage response = await httpClient.GetAsync(EndPoint + id);
                    
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        item = JsonConvert.DeserializeObject<Item?>(data) ?? new Item();
                        responseCode = DataResponseCode.OK;
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        responseCode = DataResponseCode.ResourceNotFound;
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        responseCode = DataResponseCode.BadRequest_DataInvalid;
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
                logger.LogError($"Failed to get item {id} from Item Service - {e}");
            }

            return responseFactory.CreateResponse(item, responseCode);
        }
    }
}
