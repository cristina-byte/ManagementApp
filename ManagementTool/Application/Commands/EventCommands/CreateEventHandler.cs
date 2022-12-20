using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EventCommands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand,Event>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
           var ev= await _unitOfWork.EventRepository.CreateAsync(new Event(request.Name,request.Description,
                request.Address,request.StartDate,request.EndDate));
            await _unitOfWork.Save();
            return ev;
        }
    }
}
