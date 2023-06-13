using Application.Abstraction;
using Domain.MeetingEntities;
using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class CreateMeetingHandler : IRequestHandler<CreateMeetingCommand,Meeting>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeetingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Meeting> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            
            var user = await _unitOfWork.MemberRepository.GetByIdAsync(request.UserId);

            var meeting = new Meeting(){
                Title=request.Title,
                Address=request.Address,
                StartDate=request.StartDate,
                EndDate=request.EndDate,
                Organizator=user  
            };

            await _unitOfWork.MeetingRepository.CreateAsync(meeting);

            List<int> guestsId = new List<int>(request.GuestsId);
            guestsId.Add(user.Id);

            await _unitOfWork.MeetingRepository.AddGuestsAsync(meeting,guestsId);

            await _unitOfWork.SaveAsync();
            return meeting;
        }
    }
}
