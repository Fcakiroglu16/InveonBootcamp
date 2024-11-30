using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonBootcamp.App.ISP;

namespace InveonBootcamp.App.ISP
{
    // webclient =>  read
    // mobile client => write


    public interface IReadRepository
    {
        void GetProduct();

        void GetProduct(int id);
    }

    public interface IWriteRepository
    {
        void AddProduct();
        void DeleteProduct();
        void UpdateProduct();
    }

    public interface IXRepository
    {
        void GetProduct();
        void AddProduct();
    }


    public class ProductRepository : IWriteRepository, IReadRepository, IXRepository
    {
        public void AddProduct()
        {
            Console.WriteLine("Product Added");
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Product Deleted");
        }

        public void GetProduct()
        {
            Console.WriteLine("Product Get");
        }

        public void GetProduct(int id)
        {
            Console.WriteLine("Product Get by Id");
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Product Updated");
        }
    }
}