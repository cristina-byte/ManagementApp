using Domain.MeetingEntities;
using MediatR;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingsQuery:IRequest<IEnumerable<Meeting>>
    {
       public int UserId { get; set; }
       public int Month { get; set; }
       public int Year { get; set; }
    }
}
