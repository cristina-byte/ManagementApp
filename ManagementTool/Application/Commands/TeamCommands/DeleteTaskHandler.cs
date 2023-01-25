using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class DeleteTaskHandler:IRequestHandler<DeleteTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TaskRepository.Delete(request.TaskId);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
