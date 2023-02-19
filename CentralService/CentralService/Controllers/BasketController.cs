using CentralService.DataProviders.Abstract;
using CentralService.Models.Baskets;
using CentralService.Models.Responses.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CentralService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        IHttpDataProvider<Basket?> httpDataProvider;

        public BasketController(IHttpDataProvider<Basket?> httpDataProvider)
        {
            this.httpDataProvider = httpDataProvider;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            IHttpDataResponse<Basket?> response = httpDataProvider.GetAsync(userId).GetAwaiter().GetResult();
            
            // Handle the HTTP response from the Basket Service however you see fit.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Entity);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
