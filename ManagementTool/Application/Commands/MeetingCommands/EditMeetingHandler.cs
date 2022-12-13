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
            await _unitOfWork.MeetingRepository.UpdateAsync(request.Id,
                new Meeting(request.Title,request.Address,request.StartDate,request.EndDate));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
