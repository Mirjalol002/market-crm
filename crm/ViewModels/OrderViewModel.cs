using Market.Models;

namespace Market.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public long ProductCount { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public long TotalSumm { get; set; }

        public DateTime DateTime { get; set; }

        //public IEnumerable<Product> Order { get; set; }


        public static explicit operator OrderViewModel(Order order)
        {
            return new OrderViewModel()
            {  // ClientName, ProductName,  \EmployeeName kametligi sababi int bn string bolib qovoti
                // shu sababli orderservice da to'g'irlab ketaman
                Id = order.Id,
                //ClientName = order.ClientId,
                //ProductName = order.ProductId,
                ProductCount = order.Count,
                //EmployeeName = order.EmployeeId
                TotalSumm = order.TotalSum,
                DateTime = order.DateTime,
            };
        }
    }
}
