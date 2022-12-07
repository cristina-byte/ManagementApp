using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EventCommands
{
    public class EditEventHandler:IRequestHandler<EditEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public EditEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(EditEventCommand request, CancellationToken cancellationToken)
        {
            _eventRepository.Update(request.Id, new Domain.Entities.Event(request.Name, request.Description, request.Address, request.StartDate, request.EndDate));
            return Unit.Value;
        }
    }
}
