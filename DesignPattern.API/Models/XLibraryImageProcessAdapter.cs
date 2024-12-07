using DesignPattern.API.Models.Libray;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Models
{

    public class XLibraryImageProcessAdapter : IImageProcess
    {
        public void Process(string path, string watermark)
        {
            XLibraryImageProcess xLibraryImageProcess = new XLibraryImageProcess();


            xLibraryImageProcess.Process(path, watermark, "red", false);


        }
    }
}
