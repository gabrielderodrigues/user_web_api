using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Data.Dto.User;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
