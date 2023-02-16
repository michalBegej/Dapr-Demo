using Dapr.Demo.Products.DTO;

namespace Dapr.Demo.Products.Repositories
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetAsync(int id);
    }

    public class InMemoryProductsRepository : IProductRepository
    {
        private readonly ProductDTO[] _products =
        {
            new ProductDTO(1, "Product 1", 100),
            new ProductDTO(2, "Product 2", 200),
            new ProductDTO(3, "Product 3", 300),
            new ProductDTO(4, "Product 4", 400),
        };

        public async Task<IReadOnlyCollection<ProductDTO>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public Task<ProductDTO?> GetAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(product => product.Id == id));
        }
    }
}