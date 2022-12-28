using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetChatHandler : IRequestHandler<GetChatQuery, Chat>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetChatHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Chat> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ChatRepository.GetById(request.Id);
        }
    }
}
