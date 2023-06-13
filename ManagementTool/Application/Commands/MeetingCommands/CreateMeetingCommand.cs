using Domain.MeetingEntities;
using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class CreateMeetingCommand:IRequest<Meeting>
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public IEnumerable<int> GuestsId { get; set; }
    }
}
