using Application.Abstraction;
using MediatR;

namespace Application.Commands.TeamCommands
{
    public class EditTeamHandler : IRequestHandler<EditTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditTeamCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.TeamRepository.UpdateAsync(request.Id, request.Name);
            return Unit.Value;
        }
    }
}
