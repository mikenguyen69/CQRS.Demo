using CQRS.Demo.Query.Models;
using System.Collections.Generic;

namespace CQRS.Demo.Query.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeRM>
    {
        IEnumerable<EmployeeRM> GetAll();
    }
}
