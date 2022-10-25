using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Models;
using Market.Repositories;

namespace Market.Service
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;
        public StorageService()
        {
            _storageRepository = new StorageRepository();
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            return await _storageRepository.GetAllAsync();
        }

        public async Task<Storage> GetAsync(int id)
        {

            return await _storageRepository.GetAsync(id);
        }
    }
}
