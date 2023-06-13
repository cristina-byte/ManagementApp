using Application.Abstraction;
using Domain.MeetingEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingsHandler : IRequestHandler<GetMeetingsQuery, IEnumerable<Meeting>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Meeting>> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await _unitOfWork.MeetingRepository.GetAsync(request.UserId,request.Month,request.Year);
            return meetings;
        }
    }
}
