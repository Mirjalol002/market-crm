using Market.DB_Constants;
using Market.Interface.Repositories;
using Market.Models;
using Newtonsoft.Json;

namespace Market.Repositories
{

# pragma warning disable

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _dbPath = DB_Constant.EMPLOYEES_DB;

        public async Task<bool> CreateAsync(Employee obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

                employees.Add(obj);

                json = JsonConvert.SerializeObject(employees, Formatting.Indented);

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

                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

                foreach (var employee in employees)
                {
                    if (employee.Id == id)
                    {
                        employees.Remove(employee);
                        break;
                    }
                }

                json = JsonConvert.SerializeObject(employees, Formatting.Indented);

                await File.WriteAllTextAsync(_dbPath, json);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Employee>> GetAllAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);

                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

                return employees;
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public async Task<Employee> GetAsync(int id)
        {
            // try catch dan foydalansa bo'ladi ammo bu yerda bool qaytermepkanligimiz un foydalanmadim 

            string json = await File.ReadAllTextAsync(_dbPath);

            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, Employee obj)
        {
            try
            {
                string json = await File.ReadAllTextAsync(_dbPath);
                
                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);


                employees.Add(new Employee()
                {
                    Id = id,
                    FullName = obj.FullName,
                    PhoneNumber = obj.PhoneNumber,
                    Salary = obj.Salary,
                    Description = obj.Description,
                    Gender = obj.Gender,
                    Age = obj.Age,
                    Address = obj.Address
                });

                foreach (var employee in employees)
                {
                    if (employee.Id == id)
                    {
                        employees.Remove(employee);
                        break;
                    }
                }

                json = JsonConvert.SerializeObject(employees, Formatting.Indented);

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
