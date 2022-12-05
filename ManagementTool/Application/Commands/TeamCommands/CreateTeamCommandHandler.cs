using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Application.Commands.TeamCommands
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public Task<int> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
        {
            var team = new Team(command.Id, command.Name);
            _teamRepository.Create(team);
            return Task.FromResult(team.Id);
        }
    }
}
