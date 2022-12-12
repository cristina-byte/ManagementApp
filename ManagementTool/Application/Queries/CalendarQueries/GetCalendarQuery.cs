using Domain.Entities;
using MediatR;

namespace Application.Queries.CalendarCommands
{
    public class GetCalendarQuery:IRequest<IEnumerable<Meeting>>
    {
        public int Id { get;set; }
    }
}
