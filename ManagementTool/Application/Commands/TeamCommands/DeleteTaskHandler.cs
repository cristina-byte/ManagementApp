using Application.Abstraction;
using MediatR;

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
            await _unitOfWork.TaskRepository.DeleteAsync(request.TaskId);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
