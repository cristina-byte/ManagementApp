using Application.Abstraction;
using MediatR;
using Task2 = Domain.TeamEntities.Task;

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
            var toDo = await _unitOfWork.ToDoRepository.GetByIdAsync(request.ToDoId);
            var task = new Task2 
            {
                Title=request.Title,
                ToDo=toDo
            };
          
            await _unitOfWork.TaskRepository.CreateAsync(task);
            await _unitOfWork.SaveAsync();
            return task;
        }
    }
}
