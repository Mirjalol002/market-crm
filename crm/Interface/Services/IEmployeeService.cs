using Market.Models;

namespace Market.Interface.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> GetAsync(int id);
        public Task<IEnumerable<Employee>> GetAllAsync();
    }
}
