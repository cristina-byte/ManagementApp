using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetEventsPageHandler : IRequestHandler<GetAEventsPageQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventsPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> Handle(GetAEventsPageQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetEventsPageAsync(request.Page);
        }
    }
}
