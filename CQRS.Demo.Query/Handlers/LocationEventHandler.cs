using AutoMapper;
using CQRS.Demo.Core.Events;
using CQRS.Demo.Query.Interfaces;
using CQRS.Demo.Query.Models;
using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Demo.Query.Handlers
{
    public class LocationEventHandler : IEventHandler<LocationCreatedEvent>,
        IEventHandler<EmployeeAssignedToLocationEvent>, IEventHandler<EmployeeRemovedFromLocationEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public LocationEventHandler(IMapper mapper, ILocationRepository locationRepository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _employeeRepository = employeeRepository;
        }

        public Task Handle(LocationCreatedEvent message)
        {
            LocationRM location = _mapper.Map<LocationRM>(message);

            _locationRepository.Save(location);

            return Task.CompletedTask;
        }

        public Task Handle(EmployeeAssignedToLocationEvent message)
        {
            var location = _locationRepository.GetByID(message.NewLocationID);
            location.Employees.Add(message.EmployeeID);

            _locationRepository.Save(location);

            return Task.CompletedTask;
        }

        public Task Handle(EmployeeRemovedFromLocationEvent message)
        {
            var location = _locationRepository.GetByID(message.OldLocationID);
            location.Employees.Remove(message.EmployeeID);

            _locationRepository.Save(location);

            return Task.CompletedTask;
        }
    }
}
