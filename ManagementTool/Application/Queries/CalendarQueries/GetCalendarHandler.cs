using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.CalendarCommands
{
    public class GetCalendarHandler : IRequestHandler<GetCalendarQuery,IEnumerable<Meeting>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCalendarHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Meeting>> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var calendar = await _unitOfWork.CalendarRepository.GetAsync(request.Id);
            return await _unitOfWork.MeetingRepository.GetAllAsync(calendar.Id); 
        }
    }
}
