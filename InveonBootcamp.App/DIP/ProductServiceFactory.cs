using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.App.DIP
{
    public enum CustomerDataType
    {
        SqlServer,
        Oracle
    }

    internal class ProductServiceFactory
    {
        private IProductService _instance;


        public IProductService CreateProductService(CustomerDataType customerDataType)
        {
            if (_instance is null)
            {
                if (customerDataType == CustomerDataType.Oracle)
                {
                    _instance = new ProductService(new ProductRepositoryWithOracle());
                }
                else
                {
                    _instance = new ProductService(new ProductRepository());
                }
            }

            return _instance;
        }
    }
}