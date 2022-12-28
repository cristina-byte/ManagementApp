using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System.Runtime.CompilerServices;

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
            for(int i = 0; i < request.UsersId.Count; i++)
            {
                var userId = request.UsersId.ElementAt(i);
                await _unitOfWork.TeamRepository.AddMemberAsync(userId, request.TeamId);
                var team = await _unitOfWork.TeamRepository.GetAsync(request.TeamId);
                await _unitOfWork.ChatRepository.AddParticipantAsync(userId, team.Chat.Id);
                await _unitOfWork.Save();
            }
            return Unit.Value;
        }
    }
}
