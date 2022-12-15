using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetAEventsPageQuery:IRequest<IEnumerable<Event>>
    {
        public int Page { get; set; }

    }
}

