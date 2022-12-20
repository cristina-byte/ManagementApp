using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class EditOportunityHandler : IRequestHandler<EditOportunityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditOportunityCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityRepository.UpdateAsync(request.Id,
                new Oportunity(request.Title,request.Description,request.StartDate,request.EndDate,request.Location,request.ApplicationDeadline));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
