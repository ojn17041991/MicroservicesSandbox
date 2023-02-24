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

        public BasketController(IBasketAccessor basketAccessor)
        {
            this.basketAccessor = basketAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
            IDataResponse<Basket> response = basketAccessor.PostBasketItem(basketItem);

            if (response.ResponseCode == DataResponseCode.OK)
            {
                return Ok(response.Entity);
            }
            else if (response.ResponseCode == DataResponseCode.ResourceNotFound)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else if (response.ResponseCode == DataResponseCode.ResourceDuplicated)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] BasketItem basketItem)
        {
            IDataResponse<Basket> response = basketAccessor.DeleteBasketItem(basketItem);

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
    }
}