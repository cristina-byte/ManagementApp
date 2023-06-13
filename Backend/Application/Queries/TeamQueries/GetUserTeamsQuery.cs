using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetUserTeamsQuery : IRequest<IEnumerable<Team>>
    {
        public int UserId { get; set; }

    }
}
