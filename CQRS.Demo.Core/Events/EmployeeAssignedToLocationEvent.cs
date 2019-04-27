using System;

namespace CQRS.Demo.Core.Events
{
    internal class EmployeeAssignedToLocationEvent : BaseEvent
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public EmployeeAssignedToLocationEvent(Guid id, int locationID, int employeeID)
        {
            Id = id;
            LocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}