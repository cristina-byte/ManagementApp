using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.EventQueries
{
    public class GetEventHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.EventRepository.Get(request.Id);
            return ev;
        }
    }
}
