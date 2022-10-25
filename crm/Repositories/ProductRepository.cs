using Market.DB_Constants;
using Market.Interface.Repositories;
using Market.Models;
using Newtonsoft.Json;

namespace Market.Repositories
{
#pragma warning disable
    public class ProductRepository : IProductRepository
    {

        private readonly string _dbPath = DB_Constant.PRODUCTS_DB;

        public async Task<bool> CreateAsync(Product obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                products.Add(obj);

                json = JsonConvert.SerializeObject(products, Formatting.Indented);

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

                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                foreach (var product in products)
                {
                    if (product.Id == id)
                    {
                        products.Remove(product);
                        break;
                    }
                }
                json = JsonConvert.SerializeObject(products, Formatting.Indented);

                await File.WriteAllTextAsync(_dbPath, json);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(_dbPath);

            var pruducts = JsonConvert.DeserializeObject<List<Product>>(json);

            return pruducts;
        }

        public async Task<Product> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                foreach (var product in products)
                {
                    if (product.Id == id)
                    {
                        return product;
                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, Product obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Id == id)
                    {
                        products[i] = obj;
                    }
                }
                json = JsonConvert.SerializeObject(products, Formatting.Indented);

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
