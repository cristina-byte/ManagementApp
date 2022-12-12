using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.UserCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           await _unitOfWork.MemberRepository.Create(new User(request.Name, request.Password, 
               request.Email,request.Phone, request.Cnp, request.BirthDay));
            //insert a calendar object after the user is created
           // await _unitOfWork.CalendarRepository.Create(new Calendar());
            await _unitOfWork.Save();
            return Unit.Value;  
        }
    }
}
