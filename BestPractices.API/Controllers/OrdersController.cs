using BestPractices.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace BestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMemoryCache memoryCache, IDistributedCache distributedCache) : ControllerBase
    {
        public async Task<IActionResult> Process(List<int> userIdList, CancellationToken cancellationToken)
        {
            foreach (var i in userIdList)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                //1. operation
                //2. operation
                //3. operation
            }
        }


        [HttpPost]
        public IActionResult Create(OrderCreateDto request)
        {
            var newRequest = request with { Id = 10 };


            Method1(request);
            // var result= orderService.Create(request)
        }


        private void Method1(OrderCreateDto request)
        {
            request.Id = 10;
        }
    }
}