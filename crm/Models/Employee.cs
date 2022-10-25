using Market.Enum;

namespace Market.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public long Salary { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
