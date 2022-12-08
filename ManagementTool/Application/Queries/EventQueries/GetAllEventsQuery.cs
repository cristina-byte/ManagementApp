using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetAllEventsQuery:IRequest<IEnumerable<Event>>
    {

    }
}

