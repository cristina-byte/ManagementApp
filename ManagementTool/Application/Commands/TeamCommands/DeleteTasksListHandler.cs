using Application.Abstraction;
using MediatR;

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
            await _unitOfWork.ToDoRepository.DeleteAsync(request.TasksListId);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
