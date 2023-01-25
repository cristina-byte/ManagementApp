using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class DeleteTasksListHandler : IRequestHandler<DeleteTasksListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTasksListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteTasksListCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ToDoRepository.Delete(request.TasksListId);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
