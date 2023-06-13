using Domain.Entities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTeamMembersQuery:IRequest<IEnumerable<User>>
    {
        public int TeamId { get; set; }
    }
}
