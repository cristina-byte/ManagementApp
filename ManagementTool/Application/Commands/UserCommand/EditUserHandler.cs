using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.UserCommand
{
    public class EditUserHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public EditUserHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
           await _memberRepository.Update(request.Id,new User(request.Name,request.Phone,request.Cnp,request.BirthDay));
            return Unit.Value;
        }
    }
}
