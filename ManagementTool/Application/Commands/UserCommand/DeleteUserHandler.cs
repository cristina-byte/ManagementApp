using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommand
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteUserHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _memberRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
