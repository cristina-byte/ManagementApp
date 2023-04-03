using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class CreateOportunityHandler : IRequestHandler<CreateOportunityCommand,Oportunity>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Oportunity> Handle(CreateOportunityCommand request, CancellationToken cancellationToken)
        {
            var newOportunity = new Oportunity()
            {
                Title=request.Title, 
                Description=request.Description,
                StartDate=request.StartDate, 
                EndDate=request.EndDate, 
                Location=request.Location, 
                ApplicationDeadline=request.ApplicationDeadline,
                ImageLink=request.ImageLink,
                Positions = request.Positions
            };

            await _unitOfWork.OportunityRepository.CreateAsync(newOportunity);

            await _unitOfWork.Save();
            return newOportunity;
        }
    }
}
