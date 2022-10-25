using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Models;
using Market.Repositories;

namespace Market.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }
    }
}
