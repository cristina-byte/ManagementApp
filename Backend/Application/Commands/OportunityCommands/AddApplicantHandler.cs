using Application.Abstraction;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class AddApplicantHandler : IRequestHandler<AddApplicantCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AddApplicantHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddApplicantCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityRepository.AddApplicantAsync(request.OportunityId, request.UserId,request.PositionId);
            await _unitOfWork.OportunityPositionRepository.DecrementAvailableSpotsAsync(request.PositionId);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
