using DesignPattern.API.Models.Libray;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Models
{

    public interface IImageProcess
    {
        public void Process(string path, string watermark);

    }

    public class ImageProcess : IImageProcess
    {
        public void Process(string path, string watermark)
        {
          

            Console.Write($"path:{path}, watermark:{watermark}");
        }
    }



}
