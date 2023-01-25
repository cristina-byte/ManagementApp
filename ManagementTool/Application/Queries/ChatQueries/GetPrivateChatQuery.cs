using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetPrivateChatQuery:IRequest<Chat>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
