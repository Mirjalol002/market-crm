using Market.Interface.Common;
using Market.Models;
using Market.ViewModels;

namespace Market.Interface.Repositories
{
    public interface IOrderRepository : ICreateable<OrderViewModel>,
        IUpdateable<Order>, IDeleteable<Order>,
        IReadable<Order>
    {
    }
}
