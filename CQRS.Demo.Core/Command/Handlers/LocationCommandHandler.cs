using CQRS.Demo.Core.Domain;
using CQRSlite.Commands;
using CQRSlite.Domain;
using System.Threading.Tasks;

namespace CQRS.Demo.Core.Command.Handlers
{
    public class LocationCommandHandler : ICommandHandler<CreateLocationCommand>, 
        ICommandHandler<AssignEmployeeToLocationCommand>, ICommandHandler<RemoveEmployeeFromLocationCommand>
    {
        private readonly ISession _session;

        public LocationCommandHandler(ISession session)
        {
            _session = session;
        }

        public Task Handle(CreateLocationCommand command)
        {
            var location = new Location(command.Id, command.LocationID, command.StreetAddress, command.City,
                command.State, command.PostalCode);

            _session.Add(location);
            _session.Commit();

            return Task.CompletedTask;
        }

        public Task Handle(AssignEmployeeToLocationCommand command)
        {
            Location location = _session.Get<Location>(command.Id).Result;
            location.AddEmployee(command.EmployeeID);
            _session.Commit();

            return Task.CompletedTask;
        }

        public Task Handle(RemoveEmployeeFromLocationCommand command)
        {
            Location location = _session.Get<Location>(command.Id).Result;
            location.RemoveEmployee(command.EmployeeID);
            _session.Commit();

            return Task.CompletedTask;
        }
    }
}
