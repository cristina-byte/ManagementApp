using Application.Abstraction;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class DeletePositionHandler : IRequestHandler<DeletePositionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePositionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityPositionRepository.DeleteAsync(request.Id);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
