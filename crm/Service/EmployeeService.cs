using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Models;
using Market.Repositories;

namespace Market.Service
{
    public class EmployeeService : IEmployeeService
    {
      
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _employeeRepository.GetAllAsync();


        public async Task<Employee> GetAsync(int id) => await _employeeRepository.GetAsync(id);

        // Buyog' shart emas

        //{
        //    var employee = await _employeeRepository.GetAsync(id);

        //    var employeeViewModel = (EmployeeViewModel)employee;

        //    employeeViewModel.FullName = (await _employeeRepository.GetAsync(employee.Id)).FullName;

        //    return employeeViewModel;

        //}
    }
}

