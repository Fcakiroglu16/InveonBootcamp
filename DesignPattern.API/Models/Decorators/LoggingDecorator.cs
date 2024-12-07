using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace DesignPattern.API.Models.Decarators
{
    public class LoggingDecorator(IProductService productService, ILogger<LoggingDecorator> logger) : IProductService
    {
        public Task<List<ProductDto>> GetProducts()
        {
            var stopWatch = Stopwatch.StartNew();

            var result = productService.GetProducts();

            stopWatch.Stop();
            logger.LogInformation($"GetProducts executed in {stopWatch.ElapsedMilliseconds}ms");

            return result;
        }

        public Task ImageProcess(string path, string watermark)
        {
            return productService.ImageProcess(path, watermark);
        }
    }
}