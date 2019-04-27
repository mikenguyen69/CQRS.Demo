using CQRS.Demo.Query.Interfaces;
using CQRS.Demo.Query.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Demo.Query.Repositories
{
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(IConnectionMultiplexer redisConnection) : base(redisConnection, "location") { }

        public IEnumerable<LocationRM> GetAll()
        {
            return Get<List<LocationRM>>("all");
        }

        public LocationRM GetByID(int id)
        {
            return Get<LocationRM>(id);
        }

        public IEnumerable<EmployeeRM> GetEmployees(int locationID)
        {
            return Get<List<EmployeeRM>>(locationID.ToString() + ":employees");
        }

        public new List<LocationRM> GetMultiple(List<int> ids)
        {
            return GetMultiple(ids);
        }

        public bool HasEmployee(int locationId, int employeeID)
        {
            throw new NotImplementedException();
        }

        public void Save(LocationRM item)
        {
            Save(item.LocationID, item);
            //MergeIntoAllCollection

            MergeINtoAllCollection(item);
        }

        private void MergeINtoAllCollection(LocationRM location)
        {
            List<LocationRM> allLocations = new List<LocationRM>();
            if (Exists("all"))
            {
                allLocations = GetAll().ToList();
            }

            // if the location aready exists in all collection, remove that entry
            if (allLocations.Any(x => x.LocationID == location.LocationID))
            {
                allLocations.Remove(allLocations.FirstOrDefault(x => x.LocationID == location.LocationID));
            }

            // Add the modifier district to all collection
            allLocations.Add(location);

            Save("all", allLocations);
        }
    }
}
