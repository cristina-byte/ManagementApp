
using Application.Abstraction;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Commands.ChatCommands
{
    public class CreatePrivateChatHandler : IRequestHandler<CreatePrivateChatCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePrivateChatHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePrivateChatCommand request, CancellationToken cancellationToken)
        {
            var receiver = await _unitOfWork.MemberRepository.GetByIdAsync(request.ReceiverId);
            var chat = new Chat();
            var uniqueValue = Generator.CantorPairFunction(request.SenderId, request.ReceiverId);
            chat.PrivatePair = uniqueValue;
            await _unitOfWork.ChatRepository.CreateAsync(chat);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
