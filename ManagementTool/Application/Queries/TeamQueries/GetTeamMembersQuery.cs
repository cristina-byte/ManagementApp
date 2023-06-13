using Domain.Entities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTeamMembersQuery:IRequest<ICollection<User>>
    {
        public int TeamId { get; set; }
    }
}
