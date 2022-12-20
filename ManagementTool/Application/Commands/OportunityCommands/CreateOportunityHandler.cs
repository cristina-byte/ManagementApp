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
            var oportunity=await _unitOfWork.OportunityRepository.CreateAsync(new Oportunity(request.Title, request.Description,
                request.StartDate, request.EndDate, request.Location,request.ApplicationDeadline));
            await _unitOfWork.Save();
            return oportunity;
        }
    }
}
