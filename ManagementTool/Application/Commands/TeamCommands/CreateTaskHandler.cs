using Application.Abstraction;
using MediatR;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Commands.TeamCommands
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand,Task2>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Task2> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _unitOfWork.ToDoRepository.GetAsync(request.ToDoId);
            var task = new Task2(request.Title, request.Status);
            task.ToDo = toDo;
            await _unitOfWork.TaskRepository.CreateAsync(task);
            await _unitOfWork.Save();
            return task;
        }
    }
}
