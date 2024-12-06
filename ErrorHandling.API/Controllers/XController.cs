using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            throw new Exception("db hatası");
            return Ok();
        }
    }
}