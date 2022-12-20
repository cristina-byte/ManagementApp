using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OportunityCommands
{
    public class DeleteOportunityHandler : IRequestHandler<DeleteOportunityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOportunityCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityRepository.Delete(request.Id);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
