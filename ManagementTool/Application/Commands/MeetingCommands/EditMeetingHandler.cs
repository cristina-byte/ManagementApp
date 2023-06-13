using Application.Abstraction;
using Domain.MeetingEntities;
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
            await _unitOfWork.MeetingRepository.UpdateAsync(

                new Meeting()
                {
                    Title = request.Title,
                    Address = request.Address,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                },request.Id);

            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
