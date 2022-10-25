using Market.DB_Constants;
using Market.Interface.Repositories;
using Market.Models;
using Newtonsoft.Json;

namespace Market.Repositories
{
# pragma warning disable

    public class StorageRepository : IStorageRepository
    {

        private readonly string _dbPath = DB_Constant.STORAGES_DB;

        public async Task<bool> CreateAsync(Storage obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var storages = JsonConvert.DeserializeObject<List<Storage>>(json);

                storages.Add(obj);

                json = JsonConvert.SerializeObject(storages, Formatting.Indented);

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

                var storages = JsonConvert.DeserializeObject<List<Storage>>(json);

                foreach (var storage in storages)
                {
                    if (storage.Id == id)
                    {
                        storages.Remove(storage);
                        break;
                    }
                }
                json = JsonConvert.SerializeObject(storages, Formatting.Indented);

                await File.WriteAllTextAsync(_dbPath, json);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Storage>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(_dbPath);

            var storages = JsonConvert.DeserializeObject<List<Storage>>(json);

            return storages;
        }

        public async Task<Storage> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var storages = JsonConvert.DeserializeObject<List<Storage>>(json);

                foreach (var storage in storages)
                {
                    if (storage.Id == id)
                    {
                        return storage;
                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, Storage obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var storages = JsonConvert.DeserializeObject<List<Storage>>(json);

                for (int i = 0; i < storages.Count; i++)
                {
                    if (storages[i].Id == id)
                    {
                        storages[i] = obj;
                    }
                }
                json = JsonConvert.SerializeObject(storages, Formatting.Indented);

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
