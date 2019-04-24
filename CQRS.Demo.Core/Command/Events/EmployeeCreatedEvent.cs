using System;

namespace CQRS.Demo.Core.Command.Events
{
    public class EmployeeCreatedEvent : BaseEvent
    {
        public readonly int EmployeeId;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateOfBirth;
        public readonly string JobTitle;

        public EmployeeCreatedEvent(Guid id, int employeeID, string firstName, string lastName, DateTime dateOfBirth, string jobTitle)
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
