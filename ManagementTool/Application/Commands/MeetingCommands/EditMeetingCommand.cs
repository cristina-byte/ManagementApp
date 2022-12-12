using Domain.Entities;
using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class EditMeetingCommand:IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}
