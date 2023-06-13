using Application.Abstraction;
using Domain.OportunityEntities;
using MediatR;


namespace Application.Commands.OportunityCommands
{
    public class AddOportunityPositionHandler : IRequestHandler<AddOportunityPositionCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AddOportunityPositionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddOportunityPositionCommand request, CancellationToken cancellationToken)
        {
            var oportunity = await _unitOfWork.OportunityRepository.GetByIdAsync(request.OportunityId);
            var position = new Position(){
                Name=request.Name,
                LeftSits=request.LeftSits,
                Oportunity=oportunity
            };
         
            await _unitOfWork.OportunityPositionRepository.CreateAsync(position);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
