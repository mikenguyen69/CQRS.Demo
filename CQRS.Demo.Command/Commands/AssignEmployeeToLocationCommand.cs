using System;

namespace CQRS.Demo.Command.Commands
{
    public class AssignEmployeeToLocationCommand : BaseCommand
    {
        public readonly int LocationID;
        public readonly int EmployeeID;

        public AssignEmployeeToLocationCommand(Guid id, int locationID, int employeeID)
        {
            Id = id;
            LocationID = locationID;
            EmployeeID = employeeID;
        }
    }
}