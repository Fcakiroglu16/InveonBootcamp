using DesignPattern.API.Models.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace DesignPattern.API.Models
{

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task ImageProcess(string path, string watermark);
    }



    public class ProductService(IProductRepository productRepository,IImageProcess imageProcess,ILogger<ProductService> logger,IMemoryCache memoryCache):IProductService
    {

        public async Task<List<ProductDto>> GetProducts()
        {
         

            var products= await productRepository.GetProducts();

          var  productsAsDto  = products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price * 1.2m
            }).ToList();


       

            return productsAsDto;

        }

        public async Task  ImageProcess(string path,string watermark)
        {
            imageProcess.Process(path,watermark);

        }
    }
}
