namespace DesignPattern.API.Models.Repositories
{
    public class ProductRepositoryWithSqlServer : IProductRepository
    {
        public Task<Product> AddProduct(Product product)
        {
            var exampleProduct = new Product
            {
                Id = 1,
                Name = "Example Product",
                Description = "This is an example product.",
                Price = 99.99m
            };

            throw new NotImplementedException();
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Description = "Product 1 (Sql Server)", Id = 1, Name = "Product 1", Price = 100m },
                new Product { Description = "Product 2 (Sql Server)", Id = 2, Name = "Product 2", Price = 200m }
            };

            return Task.FromResult(products);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}