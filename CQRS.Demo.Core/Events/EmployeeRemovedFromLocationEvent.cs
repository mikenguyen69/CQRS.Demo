using System;

namespace CQRS.Demo.Core.Events
{
    public class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly int OldLocationID;
        public readonly int EmployeeID;

        public EmployeeRemovedFromLocationEvent(Guid id, int locationID, int employeeID)
        {
            Id = id;
            OldLocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}