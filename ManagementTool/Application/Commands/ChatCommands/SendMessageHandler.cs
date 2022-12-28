using Application.Abstraction;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Commands.ChatCommands
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand,Chat>
    {

        private readonly IUnitOfWork _unitOfWork;

        public SendMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Chat> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var sender = await _unitOfWork.MemberRepository.GetByIdAsync(request.SenderId);
            var message = new Message(request.Content, DateTime.Now);
            message.Sender = sender;
            var chat = await _unitOfWork.ChatRepository.GetById(request.ChatId);
            message.Chat = chat;
            await _unitOfWork.MessageRepository.CreateAsync(message);
            await _unitOfWork.Save();
            return chat;
        }
    }
}
