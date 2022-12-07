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
        private readonly IMemberRepository _memberRepository;

        public CreateUserHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request.Password.Equals(request.ConfirmedPassword))
           await _memberRepository.Create(new Domain.Entities.User(request.Name, request.Password, request.Email,
                request.Phone, request.Cnp, request.BirthDay));
            return Unit.Value;
            
        }
    }
}
