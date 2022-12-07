using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EventCommands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreateEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.EventRepository.Create(new Event(request.Name,request.Description,
                request.Address,request.StartDate,request.EndDate));
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
