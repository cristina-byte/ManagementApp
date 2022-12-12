using Application.Abstraction;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Commands.TeamCommands
{
    public class AddMemberHandler : IRequestHandler<AddMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            

            return Unit.Value;
        }
    }
}
