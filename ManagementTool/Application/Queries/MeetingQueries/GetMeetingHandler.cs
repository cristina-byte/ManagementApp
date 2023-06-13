using Application.Abstraction;
using Domain.MeetingEntities;
using MediatR;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingHandler : IRequestHandler<GetMeetingQuery, Meeting>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMeetingHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Meeting> Handle(GetMeetingQuery request, CancellationToken cancellationToken)
        {
            var meeting = await _unitOfWork.MeetingRepository.GetByIdAsync(request.Id);
            return meeting;
        }
    }
}
