using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;

namespace Application.Commands.TeamCommands
{
    public class CreateToDoListHandler : IRequestHandler<CreateToDoListCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateToDoListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var team = await _unitOfWork.TeamRepository.GetAsync(request.TeamId);
            var toDo = new ToDo
            {
                Name=request.Name,
                Team=team
            };
            
            await _unitOfWork.ToDoRepository.CreateAsync(toDo);
            await _unitOfWork.Save();
            return Unit.Value; 
        }
    }
}
