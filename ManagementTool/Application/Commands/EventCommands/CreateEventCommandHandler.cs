using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EventCommands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("You are in the handler");
           await _eventRepository.CreateAsync(new Event(request.Name, request.Description, request.Address, request.StartDate, request.EndDate));
            return Unit.Value;
        }
    }
}
