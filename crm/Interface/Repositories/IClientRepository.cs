using Market.Interface.Common;
using Market.Models;

namespace Market.Interface.Repositories
{
    public interface IClientRepository : ICreateable<Client>, IUpdateable<Client>,
        IDeleteable<Client>, IReadable<Client>
    {
    }
}
