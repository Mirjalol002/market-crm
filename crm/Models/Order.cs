namespace Market.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int EmployeeId { get; set; }

        public long Count { get; set; }

        public long TotalSum { get; set; }

        public DateTime DateTime { get; set; }

    }
}
