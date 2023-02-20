using ItemService.DataAccess.Accessors.Abstract;
using ItemService.Models;
using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemAccessor itemAccessor;

        public ItemController(IItemAccessor itemAccessor)
        {
            this.itemAccessor = itemAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IDataResponse<Item> response = itemAccessor.Get(id);

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
