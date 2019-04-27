using CQRS.Demo.Query.Interfaces;
using CQRS.Demo.Query.Models;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Demo.Query.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "employee") { }

        public IEnumerable<EmployeeRM> GetAll()
        {
            return Get<List<EmployeeRM>>("all");
        }

        public EmployeeRM GetByID(int id)
        {
            return Get<EmployeeRM>(id);
        }

        public new List<EmployeeRM> GetMultiple(List<int> ids)
        {
            return GetMultiple(ids);
        }

        public void Save(EmployeeRM employee)
        {
            Save(employee.EmployeeID, employee);
            MergeIntoAllCollection(employee);
        }

        private void MergeIntoAllCollection(EmployeeRM employee)
        {
            List<EmployeeRM> allEmployees = new List<EmployeeRM>();
            if (Exists("all"))

            {
                allEmployees = Get<List<EmployeeRM>>("all");
            }

            if (allEmployees.Any(x => x.EmployeeID == employee.EmployeeID))
            {
                allEmployees.Remove(allEmployees.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID));
            }

            allEmployees.Add(employee);

            Save("all", allEmployees);
        }
    }
}
