using Market.Models;

namespace Market.Interface.Services
{
    public interface IClientService
    {
        public Task<Client> GetAsync(int id);
        public Task<IEnumerable<Client>> GetAllAsync(); // IEnumerable bo'lganligi sababi GetAll faqat qaytarib yuvoramiz 
    }
}

