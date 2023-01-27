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
            await _unitOfWork.OportunityRepository.AddApplicant(request.OportunityId, request.UserId,request.PositionId);
            await _unitOfWork.OportunityPositionRepository.Update(request.PositionId);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
