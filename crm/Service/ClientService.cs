using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Models;
using Market.Repositories;
using System.Linq;

namespace Market.Service
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;
        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<Client> GetAsync(int id)
        {
            var res = await _clientRepository.GetAsync(id);

            IList<Client> client = new List<Client>();

            foreach (var item in client)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null!;

            //return await _clientRepository.GetAsync(id);

        }
    }
}
