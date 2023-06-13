using Application.Abstraction;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class DeleteOportunityHandler : IRequestHandler<DeleteOportunityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOportunityCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityRepository.DeleteAsync(request.Id);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
