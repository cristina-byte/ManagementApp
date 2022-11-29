using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Queries.TeamQueries
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, Team>
    {
        private ITeamRepository _teamRepository;

        public GetTeamQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<Team> Handle(GetTeamQuery query, CancellationToken cancellationToken)
        {
            var team = _teamRepository.GetByName(query.Name);
            return Task.FromResult(team);
        }
    }
}
