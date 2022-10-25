using Market.DB_Constants;
using Market.Interface.Repositories;
using Market.Models;
using Market.ViewModels;
using Newtonsoft.Json;

namespace Market.Repositories
{
#pragma warning disable
    public class OrderRepository : IOrderRepository
    {
        private readonly string _dbPath = DB_Constant.ORDERS_DB;

        public async Task<bool> CreateAsync(OrderViewModel obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var orders = JsonConvert.DeserializeObject<List<OrderViewModel>>(json);

                orders.Add(obj);

                json = JsonConvert.SerializeObject(orders, Formatting.Indented);

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

                var orders = JsonConvert.DeserializeObject<List<Order>>(json);

                foreach (var order in orders)
                {
                    if (order.Id == id)
                    {
                        orders.Remove(order);
                        break;
                    }
                }

                json = JsonConvert.SerializeObject(orders, Formatting.Indented);

                await File.WriteAllTextAsync(_dbPath, json);

                return true;

            }
            catch
            {
                return false;
            }
        }


        public async Task<IList<Order>> GetAllAsync()
        {
            string json = await File.ReadAllTextAsync(_dbPath);

            var orders = JsonConvert.DeserializeObject<List<Order>>(json);

            return orders;
        }

        public async Task<Order> GetAsync(int id)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var orders = JsonConvert.DeserializeObject<List<Order>>(json);

                foreach (var order in orders)
                {
                    if (order.Id == id)
                    {
                        return order;
                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, Order obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var orders = JsonConvert.DeserializeObject<List<Order>>(json);

                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].Id == id)
                    {
                        orders[i] = obj;
                    }
                }
                json = JsonConvert.SerializeObject(orders, Formatting.Indented);

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
