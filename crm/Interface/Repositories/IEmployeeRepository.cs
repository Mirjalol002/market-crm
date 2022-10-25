using Market.Interface.Common;
using Market.Models;

namespace Market.Interface.Repositories
{
    public interface IEmployeeRepository : ICreateable<Employee>,
        IReadable<Employee>, IUpdateable<Employee>, IDeleteable<Employee>
    {
    }
}
