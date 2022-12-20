using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TeamRepository.Delete(request.Id);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
