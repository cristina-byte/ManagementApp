using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetUpcomingEventsHandler : IRequestHandler<GetUpcomingEventsQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUpcomingEventsHandler(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetUpcomingPageAsync(request.Page);
        }
    }
}
