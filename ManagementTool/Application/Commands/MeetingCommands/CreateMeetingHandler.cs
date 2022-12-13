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
            
            var user = await _unitOfWork.MemberRepository.GetByIdAsync(request.UserId);
            var meeting = new Meeting(request.Title, request.Address, request.StartDate,request.EndDate);
            meeting.Organizator = user;
            await _unitOfWork.MeetingRepository.CreateAsync(meeting);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
