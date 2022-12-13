using Application.Abstraction;
using Domain.Entities;
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
            var user = await _unitOfWork.MemberRepository.GetByIdAsync(command.AdminId);
            var team = new Team(command.Name);
            team.Admin = user;
            var chat = new Chat();
            chat.Name = team.Name;
           Chat c= await _unitOfWork.ChatRepository.CreateAsync(chat);
            team.Chat = c;
            await _unitOfWork.TeamRepository.CreateAsync(team);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
