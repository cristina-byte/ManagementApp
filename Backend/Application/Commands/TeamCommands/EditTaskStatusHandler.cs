using Application.Abstraction;
using MediatR;

namespace Application.Commands.TeamCommands
{
    public class EditTaskStatusHandler : IRequestHandler<EditTaskStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditTaskStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditTaskStatusCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TaskRepository.UpdateAsync(request.TaskId, request.IsDone);
            await _unitOfWork.SaveAsync();
            return Unit.Value; 
        }
    }
}
