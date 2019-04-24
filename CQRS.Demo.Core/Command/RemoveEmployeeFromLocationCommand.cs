using System;

namespace CQRS.Demo.Core.Command
{
    public class RemoveEmployeeFromLocationCommand : BaseCommand
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public RemoveEmployeeFromLocationCommand(Guid id, int locationID, int employeeID)
        {
            Id = id;
            LocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}