namespace ErrorHandling.API.Model
{
    public class ProductNotFoundException(int id) : Exception($"Product not found with id {id}");
}