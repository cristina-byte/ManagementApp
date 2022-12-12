using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class EditMeetingHandler : IRequestHandler<EditMeetingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMeetingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EditMeetingCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.MeetingRepository.Update(request.Id,
                new Meeting(request.Title,request.Address,request.Date));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
