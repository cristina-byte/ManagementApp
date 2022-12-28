using Domain.Entities;
using MediatR;

namespace Application.Commands.ChatCommands
{
    public class SendMessageCommand:IRequest<Chat>
    { 
        public int SenderId { get; set; }
        public string Content { get; set; }
        public int ChatId { get; set; }
        
    }
}
