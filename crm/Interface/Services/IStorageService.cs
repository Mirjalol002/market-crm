using Market.Models;

namespace Market.Interface.Services
{
    public interface IStorageService
    {
        public Task<Storage> GetAsync(int id);
        public Task<IEnumerable<Storage>> GetAllAsync();
    }
}
