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
            var newOportunity = new Oportunity(){
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                ApplicationDeadline = request.ApplicationDeadline,
                ImageLink = request.ImageLink,
                Positions = request.Positions
            };
            
            await _unitOfWork.OportunityRepository.UpdateAsync(request.Id, newOportunity);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
