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
           await _unitOfWork.MemberRepository.Update(request.Id,new User(request.Name,request.Phone,
               request.Cnp,request.BirthDay));
           await _unitOfWork.Save();
           return Unit.Value;
        }
    }
}
