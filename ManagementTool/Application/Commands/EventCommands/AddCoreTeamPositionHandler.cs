using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EventCommands
{
    public class AddCoreTeamPositionHandler : IRequestHandler<AddCoreTeamPositionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCoreTeamPositionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddCoreTeamPositionCommand request, CancellationToken cancellationToken)
        {
            var position = new CoreTeamPosition(request.Name);
            position.User = await _unitOfWork.MemberRepository.GetByIdAsync(request.UserId);
            position.Event = await _unitOfWork.EventRepository.GetAsync(request.EventId);
            await _unitOfWork.CoreTeamPositionRepository.CreateAsync(position);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
