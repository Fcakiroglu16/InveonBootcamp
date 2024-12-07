using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Models.Libray
{

    public class XLibraryImageProcess 
    {
        public void Process(string path, string watermark,string color,bool dimension)
        {
            Console.Write($"path:{path}, watermark:{watermark}");
        }
    }
}
