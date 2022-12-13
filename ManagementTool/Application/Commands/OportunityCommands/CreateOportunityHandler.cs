using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;

namespace Application.Commands.OportunityCommands
{
    public class CreateOportunityHandler : IRequestHandler<CreateOportunityCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateOportunityCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OportunityRepository.CreateAsync(new Oportunity(request.Title, request.Description,
                request.StartDate, request.EndDate, request.Location));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
