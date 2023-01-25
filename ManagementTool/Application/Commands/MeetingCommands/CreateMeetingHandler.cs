using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;

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
            var meeting = new Meeting(request.Title, request.Address, request.StartDate,request.EndDate);
            meeting.Organizator = user;
            
            var createdMeeting = await _unitOfWork.MeetingRepository.CreateAsync(meeting);

            List<int> guestsId = new List<int>(request.GuestsId);
            guestsId.Add(user.Id);

            await _unitOfWork.MeetingRepository.AddGuests(createdMeeting,guestsId);

            await _unitOfWork.Save();
            return createdMeeting;
        }
    }
}
