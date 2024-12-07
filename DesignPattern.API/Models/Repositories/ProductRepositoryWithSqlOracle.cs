namespace DesignPattern.API.Models.Repositories
{
    public class ProductRepositoryWithSqlOracle : IProductRepository
    {
        public Task<Product> AddProduct(Product product)
        {
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


            var product1 = new Product() { Description = "Product 1 (Oracle)", Id = 1, Name = "Product 1", Price = 100.00m };


            var product2 = new Product() { Description = "Product 2 (Oracle)", Id = 2, Name = "Product 2", Price = 200.00m };


            return Task.FromResult(new List<Product>() { product1, product2 });

        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
