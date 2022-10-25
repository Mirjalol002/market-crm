using Market.Interface.Common;
using Market.Models;

namespace Market.Interface.Repositories
{
    public interface IProductRepository : ICreateable<Product>,
        IUpdateable<Product>, IDeleteable<Product>,
        IReadable<Product>
    {
    }
}
