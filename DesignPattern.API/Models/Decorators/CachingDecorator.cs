using Microsoft.Extensions.Caching.Memory;

namespace DesignPattern.API.Models.Decorators
{
    public class CachingDecorator(IProductService productService, IMemoryCache memoryCache) : IProductService
    {
        public async Task<List<ProductDto>> GetProducts()
        {
            var cacheKey = "Products";
            if (memoryCache.TryGetValue(cacheKey, out List<ProductDto>? productsAsDto))
            {
                return productsAsDto!;
            }


            productsAsDto = await productService.GetProducts();


            memoryCache.Set(cacheKey, productsAsDto, TimeSpan.FromMinutes(5));

            return productsAsDto;
        }

        public Task ImageProcess(string path, string watermark)
        {
            throw new NotImplementedException();
        }
    }
}