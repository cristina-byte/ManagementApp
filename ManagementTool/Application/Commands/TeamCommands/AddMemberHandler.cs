using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Commands.TeamCommands
{
    public class AddMemberHandler : IRequestHandler<AddMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TeamRepository.AddMemberAsync(request.UserId, request.TeamId);
            var team = await _unitOfWork.TeamRepository.GetAsync(request.TeamId);
            var chatMember = new ChatMember(request.UserId, team.Chat.Id);
            await _unitOfWork.ChatRepository.AddParticipantAsync(request.UserId, team.Chat.Id);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
