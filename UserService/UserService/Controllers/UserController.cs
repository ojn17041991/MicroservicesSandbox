using MicroserviceCommonObjects.Data.DataResponses.Abstract;
using MicroserviceCommonObjects.Enums;
using Microsoft.AspNetCore.Mvc;
using UserService.DataAccess.Accessors.Abstract;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAccessor userAccessor;

        public UserController(IUserAccessor userAccessor)
        {
            this.userAccessor = userAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IDataResponse<User> response = userAccessor.Get(id);

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
        public IActionResult Post(User user)
        {
            IDataResponse<User> response = userAccessor.Post(user);



            return Ok(response.Entity);
        }
    }
}
