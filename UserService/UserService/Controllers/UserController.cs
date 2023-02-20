using Microsoft.AspNetCore.Mvc;
using UserService.DataAccess.Accessors.Abstract;

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
        public string Get(int id)
        {
            return "value";
        }
    }
}
