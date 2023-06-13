using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.UserCommand
{
    public class EditUserHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
           await _unitOfWork.MemberRepository.UpdateAsync(request.ImageLink ,request.Id);
           await _unitOfWork.SaveAsync();
           return Unit.Value;
        }
    }
}
