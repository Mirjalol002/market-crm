using Market.Models;

namespace Market.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public static explicit operator EmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
            };
        }
    }
}

