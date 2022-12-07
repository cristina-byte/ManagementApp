using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.EventQueries
{
    public class GetEventHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        { 
           var ev= await _eventRepository.Get(request.Id);
            return ev;
        }
    }
}
