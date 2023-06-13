using Application.Abstraction;
using MediatR;

namespace Application.Commands.TeamCommands
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TeamRepository.DeleteAsync(request.Id);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
