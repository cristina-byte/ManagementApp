using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;

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
            var user = await _unitOfWork.MemberRepository.GetById(command.AdminId);
            var team = new Team(command.Name);
            team.Admin = user;

            await _unitOfWork.TeamRepository.Create(team);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
