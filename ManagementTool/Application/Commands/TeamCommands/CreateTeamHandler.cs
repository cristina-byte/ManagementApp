using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Application.Commands.TeamCommands
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
 
        public async Task<Unit> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
        {
            var team = new Team(command.Id, command.Name);
            await _unitOfWork.TeamRepository.Create(team);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
