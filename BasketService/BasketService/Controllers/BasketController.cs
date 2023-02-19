using BasketService.Model;
using MicroserviceCommonObjects.Data.DataAccessors.Abstract;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IDataAccessor<Basket> basketAccessor;

        public BasketController(IDataAccessor<Basket> basketAccessor)
        {
            this.basketAccessor = basketAccessor;
        }

        [HttpGet("{userId}")]
        public Basket Get(int userId)
        {
            IDataResponse<Basket> basket = basketAccessor.Get(userId);
            return basket.Entity;
        }

        //[HttpPost]

        //[HttpDelete]
    }
}
