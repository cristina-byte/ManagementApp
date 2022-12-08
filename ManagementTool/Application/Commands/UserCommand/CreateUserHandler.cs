using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           await _unitOfWork.MemberRepository.Create(new Domain.Entities.User(request.Name, request.Password, 
               request.Email,request.Phone, request.Cnp, request.BirthDay));
            await _unitOfWork.Save();
            return Unit.Value;  
        }
    }
}
