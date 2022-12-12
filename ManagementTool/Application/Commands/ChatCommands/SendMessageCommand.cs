using MediatR;

namespace Application.Commands.ChatCommands
{
    public class SendMessageCommand:IRequest
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
