using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetInProcessEventsHandler : IRequestHandler<GetInProcessEventsQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetInProcessEventsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Event>> Handle(GetInProcessEventsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.EventRepository.GetInProcess();
        }
    }
}
