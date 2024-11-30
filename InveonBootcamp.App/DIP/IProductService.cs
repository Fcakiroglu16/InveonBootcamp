using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.App.DIP
{
    internal interface IProductService
    {
        List<Product> GetAll();
    }
}