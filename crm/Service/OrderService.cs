using Market.Interface.Repositories;
using Market.Interface.Services;
using Market.Repositories;
using Market.ViewModels;

namespace Market.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _employeeRepository = new EmployeeRepository();
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var orderViewModel = (OrderViewModel)order;
                orderViewModel.EmployeeName = (await _employeeRepository.GetAsync(order.EmployeeId)).FullName;
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }

        public async Task<OrderViewModel> GetAsync(int id)
        {
            var order = await _orderRepository.GetAsync(id);

            var orderViewModel = (OrderViewModel)order;

            orderViewModel.EmployeeName = (await _employeeRepository.GetAsync(order.EmployeeId)).FullName;

            return orderViewModel;

        }
    }
}
