namespace InveonBootcamp.App.DIP
{
    internal class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            var productList = _productRepository.GetAll();
            Console.WriteLine();

            foreach (var product in productList)
            {
                product.Price = product.Price * 1.2m;
            }

            return productList;
        }
    }
}