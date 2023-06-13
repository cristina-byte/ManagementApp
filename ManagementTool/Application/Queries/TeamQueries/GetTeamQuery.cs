using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTeamQuery : IRequest<Team>
    {
        public int Id { get; set; }
    }
}
