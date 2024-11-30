using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.App.DIP
{
    internal class ProductRepositoryWithOracle : IProductRepository
    {
        public List<Product> GetAll()
        {
            return
            [
                new Product { Id = 1, Price = 1100 },
                new Product { Id = 2, Price = 1200 },
                new Product { Id = 3, Price = 1300 }
            ];
        }
    }
}