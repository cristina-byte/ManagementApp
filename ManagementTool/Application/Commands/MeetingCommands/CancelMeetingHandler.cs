﻿using Application.Abstraction;
using MediatR;

namespace Application.Commands.MeetingCommands
{
    public class CancelMeetingHandler : IRequestHandler<CancelMeetingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelMeetingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CancelMeetingCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.MeetingRepository.Delete(request.Id);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
