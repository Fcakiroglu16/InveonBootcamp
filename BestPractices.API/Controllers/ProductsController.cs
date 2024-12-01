using BestPractices.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }


        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Create()
        {
            var status = true;

            if (status)
            {
                return Ok();
            }

            return BadRequest(new ProblemDetails()
            {
            });
        }

        [HttpPost("full")]
        public IActionResult CreateFullProduct()
        {
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderUpdateDto requestBody)
        {
            return Ok();
        }


        [HttpPatch("stock/{stockId}")]
        public IActionResult UpdateStock(int stockId)
        {
            return Ok();
        }

        //Route constraint
        [HttpDelete("{id:min(40)}/{name:length(3)}")]
        public IActionResult Delete(int id, string name)
        {
            return Ok();
        }
        // simple type (int,double,datetime,string)
        // complex type( class,record,struct)

        // try-catch
        // business code
        // fat controller
        // ProductsController(IProductService,ICacheService,IXServive;IHashService)
        // Unit Test / Integration Test / End-to-End Test
    }
}