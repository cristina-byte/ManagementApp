using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetUpcomingEventsQuery:IRequest<IEnumerable<Event>>
    {
    }
}
