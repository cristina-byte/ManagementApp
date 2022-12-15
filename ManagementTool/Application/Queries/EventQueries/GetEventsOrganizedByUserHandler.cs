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
    public class GetEventsOrganizedByUserHandler : IRequestHandler<GetEventsOrganizedByUserQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsOrganizedByUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Event>> Handle(GetEventsOrganizedByUserQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
