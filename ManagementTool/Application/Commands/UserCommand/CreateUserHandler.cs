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
            Console.WriteLine("Hello from command");
           await _unitOfWork.MemberRepository.CreateAsync(new User(request.Name, request.Password, 
               request.Email,request.Phone, request.Cnp, request.BirthDay));
            await _unitOfWork.Save();
            return Unit.Value;  
        }
    }
}
