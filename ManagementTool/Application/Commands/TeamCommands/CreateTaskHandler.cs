using Application.Abstraction;
using MediatR;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Commands.TeamCommands
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _unitOfWork.ToDoRepository.GetById(request.ToDoId);
            var task = new Task2(request.Title, request.Status);
            task.ToDo = toDo;
            await _unitOfWork.TaskRepository.Create(task);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
