using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetEventQuery:IRequest<Event>
    {
        public int Id { get; set; }

    }
}
