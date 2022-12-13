using MediatR;

namespace Application.Commands.ChatCommands
{
    public class CreatePrivateChatCommand:IRequest
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
