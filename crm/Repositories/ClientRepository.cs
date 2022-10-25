using Market.DB_Constants;
using Market.Interface.Repositories;
using Market.Models;
using Newtonsoft.Json;

namespace Market.Repositories
{

# pragma warning disable

    public class ClientRepository : IClientRepository
    {
        private readonly string _dbPath = DB_Constant.CLIENTS_DB;

        public async Task<bool> CreateAsync(Client obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var clients = JsonConvert.DeserializeObject<List<Client>>(json);

                clients.Add(obj);

                json = JsonConvert.SerializeObject(clients, Formatting.Indented);

                await File.WriteAllTextAsync(_dbPath, json);

                return true;

            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var clients = JsonConvert.DeserializeObject<List<Client>>(json);

                foreach (var client in clients)
                {
                    if (client.Id == id)
                    {
                        clients.Remove(client);
                        break;
                    }
                }
                json = JsonConvert.SerializeObject(clients, Formatting.Indented);
                await File.WriteAllTextAsync(_dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IList<Client>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(_dbPath);

            var clients = JsonConvert.DeserializeObject<List<Client>>(json);

            return clients;

        }

        public async Task<Client> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var clients = JsonConvert.DeserializeObject<List<Client>>(json);

                foreach (var client in clients)
                {
                    if (client.Id == id)
                    {
                        return client;
                        
                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, Client obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var clients = JsonConvert.DeserializeObject<List<Client>>(json);

                for (int i = 0; i < clients.Count; i++)
                {
                    if (clients[i].Id == id)
                    {
                        clients[i] = obj;
                    }
                }

                json = JsonConvert.SerializeObject(clients, Formatting.Indented);
                await File.WriteAllTextAsync(_dbPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
