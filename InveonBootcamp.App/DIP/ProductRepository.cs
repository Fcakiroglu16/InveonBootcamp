namespace InveonBootcamp.App.DIP
{
    internal class ProductRepository : IProductRepository
    {
        public static int Kdv = 20;

        public List<Product> GetAll()
        {
            // return product list

            return
            [
                new Product { Id = 1, Price = 100 },
                new Product { Id = 2, Price = 200 },
                new Product { Id = 3, Price = 300 }
            ];
        }
    }
}