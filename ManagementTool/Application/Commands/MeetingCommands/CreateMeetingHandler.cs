using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Commands.MeetingCommands
{
    public class CreateMeetingHandler : IRequestHandler<CreateMeetingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeetingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var calendar = await _unitOfWork.CalendarRepository.Get(request.CalendarId);
            var user = await _unitOfWork.MemberRepository.GetById(request.UserId);
            var meeting = new Meeting(request.Title, request.Address, request.Date);
            meeting.Calendar = calendar;
            meeting.Organizator = user;
            await _unitOfWork.MeetingRepository.Create(meeting);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
