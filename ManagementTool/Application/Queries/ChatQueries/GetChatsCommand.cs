using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetChatsCommand:IRequest<IEnumerable<Chat>>
    {
        public int UserId { get; private set; }
    }
}
