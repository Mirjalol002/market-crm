using Market.Interface.Common;
using Market.Models;

namespace Market.Interface.Repositories
{
    public interface IStorageRepository : ICreateable<Storage>,
        IUpdateable<Storage>, IReadable<Storage>,
        IDeleteable<Storage>
    {
    }
}
