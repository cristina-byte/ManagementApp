using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetChatQuery:IRequest<Chat>
    {
        public int Id { get; set; }
    }
}
