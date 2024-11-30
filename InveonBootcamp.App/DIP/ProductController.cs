namespace InveonBootcamp.App.DIP;

internal class ProductController(IProductService productService)
{
    public List<Product> GetAll()
    {
        return productService.GetAll();
    }
}