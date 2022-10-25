using Market.ViewModels;

namespace Market.Interface.Services
{
    public interface IOrderService
    {
        public Task<OrderViewModel> GetAsync(int id);
        public Task<IEnumerable<OrderViewModel>> GetAllAsync();

    }
}
