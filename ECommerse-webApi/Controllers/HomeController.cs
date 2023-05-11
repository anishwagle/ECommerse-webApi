using Ecommerce_webApi.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse_webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            var success = new Response<int>();
            success.CreateSuccess(1234);
            return Ok(success);
        }
    }
}
