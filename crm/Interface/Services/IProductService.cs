using Market.Models;

namespace Market.Interface.Services
{
    public interface IProductService
    {
        public Task<Product> GetAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}
