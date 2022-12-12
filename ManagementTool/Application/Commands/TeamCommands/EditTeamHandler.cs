using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class EditTeamHandler : IRequestHandler<EditTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditTeamCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TeamRepository.UpdateNameAsync(request.Id, request.Name);
            return Unit.Value;
        }
    }
}
