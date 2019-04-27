using CQRS.Demo.Query.Models;
using System.Collections.Generic;

namespace CQRS.Demo.Query.Interfaces
{
    public interface ILocationRepository : IBaseRepository<LocationRM>
    {
        IEnumerable<LocationRM> GetAll();
        IEnumerable<EmployeeRM> GetEmployees(int locationID);
        bool HasEmployee(int locationId, int employeeID);
    }
}
