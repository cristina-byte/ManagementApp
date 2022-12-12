using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var oportunity = await _unitOfWork.OportunityRepository.Get(request.OportunityId);
            var position = new Position(request.Name, request.LeftSits);
            position.Oportunity = oportunity;
            await _unitOfWork.OportunityPositionRepository.Create(position);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
