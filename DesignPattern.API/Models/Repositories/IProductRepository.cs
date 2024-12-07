namespace DesignPattern.API.Models.Repositories
{
    public interface IProductRepository
    {
        //create crud operation
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);




    }
}
