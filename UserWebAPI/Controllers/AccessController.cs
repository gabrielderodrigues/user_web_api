using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Access allowed.");
        }
    }
}
