using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;

namespace ErrorHandling.API.Model.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
    }

    public class ProductService(MemoryCache memoryCache)
    {
        public ServiceResult<ProductDto> Get(int id)
        {
            int a = 10;
            int b = 20;

            if (b == 0)
            {
                throw new DivideByZeroException();
            }


            throw new ProductNotFoundException(5);


            try
            {
                var c = a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            if (memoryCache.TryGetValue("key", out object data))
            {
            }
            else
            {
            }
            //try
            //{
            //    var data = memoryCache.Get("key");
            //}
            //catch (Exception e)
            //{

            //    // fetch from db

            //}


            return new ServiceResult<ProductDto>()
            {
                Data = new ProductDto(1, "kalem 1", 100)
            };


            return new ServiceResult<ProductDto>()
            {
                Errors = []
            };
        }
    }
}