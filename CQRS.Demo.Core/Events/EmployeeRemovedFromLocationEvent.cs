using System;

namespace CQRS.Demo.Core.Events
{
    internal class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public EmployeeRemovedFromLocationEvent(Guid id, int locationID, int employeeID)
        {
            Id = id;
            LocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}