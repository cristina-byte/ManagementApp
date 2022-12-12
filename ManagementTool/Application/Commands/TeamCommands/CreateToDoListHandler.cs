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
            var team = await _unitOfWork.TeamRepository.Get(request.TeamId);
            var toDo = new ToDo(request.Name);
            toDo.Team = team;
            await _unitOfWork.ToDoRepository.Create(toDo);
            await _unitOfWork.Save();
            return Unit.Value; 
        }
    }
}
