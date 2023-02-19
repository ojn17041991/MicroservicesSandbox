using BasketService.DataAccess.Accessors.Abstract;
using BasketService.Model;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketAccessor basketAccessor;
        private IBasketItemAccessor basketItemAccessor;

        public BasketController(IBasketAccessor basketAccessor, IBasketItemAccessor basketItemAccessor)
        {
            this.basketAccessor = basketAccessor;
            this.basketItemAccessor = basketItemAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult GetByUserId(int id)
        {
            IDataResponse<Basket> response = basketAccessor.Get(id);

            if (response.ResponseCode == DataResponseCode.OK)
            {
                return Ok(response.Entity);
            }
            else if (response.ResponseCode == DataResponseCode.ResourceNotFound)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BasketItem basketItem)
        {
            IDataResponse<BasketItem> response = basketItemAccessor.Post(basketItem);

            if (response.ResponseCode == DataResponseCode.OK)
            {
                return Ok(response.Entity);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] BasketItem basketItem)
        {
            IDataResponse<BasketItem> response = basketItemAccessor.Delete(basketItem);

            if (response.ResponseCode == DataResponseCode.OK)
            {
                return Ok(response.Entity);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
