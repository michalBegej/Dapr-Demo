using Dapr.Demo.Orders.DTO;

namespace Dapr.Demo.Orders.Clients
{
    public class ProductsClient
    {
        private readonly HttpClient _httpClient;

        public ProductsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<ProductDTO?>> GetProducts(IEnumerable<int> productIds)
        {
            var tasks = productIds.Select(id => _httpClient.GetFromJsonAsync<ProductDTO>($"products/{id}"));

            return await Task.WhenAll(tasks);
        }
    }
}