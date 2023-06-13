using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class AddGuestsCommand:IRequest
    {
      public ICollection<int> UsersId { get; set; }
        public int MeetingId { get; set; }
    }
}
