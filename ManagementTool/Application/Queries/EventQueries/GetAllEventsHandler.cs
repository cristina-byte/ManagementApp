using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEventsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetAllAsync();
        }
    }
}
