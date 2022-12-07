using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Queries.TeamQueries
{
    public class GetTeamHandler : IRequestHandler<GetTeamQuery, Team>
    {
        private ITeamRepository _teamRepository;

        public GetTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<Team> Handle(GetTeamQuery query, CancellationToken cancellationToken)
        {
            var team = _teamRepository.Get(query.Id);
            return team;
        }
    }
}
