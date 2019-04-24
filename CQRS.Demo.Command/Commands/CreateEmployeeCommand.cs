using System;

namespace CQRS.Demo.Command.Commands
{
    public class CreateEmployeeCommand : BaseCommand
    {
        public readonly int EmployeeId;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateOfBirth;
        public readonly string JobTitle;

        public CreateEmployeeCommand(Guid id, int employeeID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
        {
            Id = id;
            EmployeeId = employeeID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }
    }
}
