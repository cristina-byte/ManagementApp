using Application.Abstraction;
using MediatR;

namespace Application.Commands.TeamCommands
{
    public class AddMembersHandler : IRequestHandler<AddMembersCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMembersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddMembersCommand request, CancellationToken cancellationToken)
        {
            foreach(int userId in request.UsersId)
            {
                await _unitOfWork.TeamRepository.AddMemberAsync(userId, request.TeamId);
                //var team = await _unitOfWork.TeamRepository.GetAsync(request.TeamId);
                //await _unitOfWork.ChatRepository.AddParticipantAsync(userId, team.Chat.Id);
                await _unitOfWork.Save();
            }
            return Unit.Value;
        }
    }
}
