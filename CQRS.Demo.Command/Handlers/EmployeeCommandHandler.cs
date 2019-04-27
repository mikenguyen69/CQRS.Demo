using CQRS.Demo.Command.Commands;
using CQRS.Demo.Core.Domain;
using CQRSlite.Commands;
using CQRSlite.Domain;
using System.Threading.Tasks;

namespace CQRS.Demo.Command.Handlers
{
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly ISession _session;

        public EmployeeCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(CreateEmployeeCommand command)
        {
            Employee employee = new Employee(command.Id, command.EmployeeId, command.FirstName, 
                command.LastName, command.DateOfBirth, command.JobTitle);

            _session.Add(employee);
            _session.Commit();

            return Task.CompletedTask;
        }
    }
}
