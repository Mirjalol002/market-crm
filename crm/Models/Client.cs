using Market.Enum;

namespace Market.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public Gender Gender { get; set; }
    }
}
