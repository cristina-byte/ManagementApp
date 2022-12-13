using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetChatsQuery:IRequest<IEnumerable<Chat>>
    {
        public int UserId { get; private set; }
    }
}
