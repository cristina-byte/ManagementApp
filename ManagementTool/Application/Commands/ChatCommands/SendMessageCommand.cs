using MediatR;

namespace Application.Commands.ChatCommands
{
    public class SendMessageCommand:IRequest
    { 
        public int SenderId { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        
    }
}
