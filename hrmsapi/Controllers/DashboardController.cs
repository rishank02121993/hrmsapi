using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hrmsapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet("demo")]
        public IActionResult DemoAction()
        {
            // This action will only be accessible to authorized users
            return Ok("Welcome to the Dashboard! You are authorized.");
        }
    }
}
