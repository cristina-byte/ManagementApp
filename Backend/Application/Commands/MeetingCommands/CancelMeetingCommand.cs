using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class CancelMeetingCommand:IRequest
    {
        public int Id { get; set; }
    }
}
