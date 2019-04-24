using CQRS.Demo.Core.Command;
using CQRS.Demo.Core.Command.Events;
using CQRSlite.Domain;
using System;
using System.Collections.Generic;

namespace CQRS.Demo.Core.Domain
{
    public class Location : AggregateRoot
    {
        private int _locationID;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _postalCode;
        private List<int> _employees;

        private Location() { }

        public Location(Guid id, int locationID, string streetAddress, string city, string state, 
            string postalCode)
        {
            Id = id;
            _locationID = locationID;
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _employees = new List<int>();

            ApplyChange(new LocationCreatedEvent(id, locationID, streetAddress, city, state, postalCode)); 
        }

        public void AddEmployee(int employeeID)
        {
            _employees.Add(employeeID);
            ApplyChange(new EmployeeAssignedToLocationEvent(Id, _locationID, employeeID));
        }

        public void RemoveEmployee(int employeeID)
        {
            _employees.Remove(employeeID);
            ApplyChange(new EmployeeRemovedFromLocationEvent(Id, _locationID, employeeID));
        }
    }
}
