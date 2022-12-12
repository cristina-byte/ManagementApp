using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.ChatCommands
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public SendMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            //inainte de a trimite mesajul se verifica daca exista un chat privat cu persoana


            var sender = await _unitOfWork.MemberRepository.GetByIdAsync(request.SenderId);
            var message = new Message(request.Content, DateTime.Now);
            message.Sender = sender;
            await _unitOfWork.MessageRepository.CreateAsync(message);
            return Unit.Value;
        }
    }
}
