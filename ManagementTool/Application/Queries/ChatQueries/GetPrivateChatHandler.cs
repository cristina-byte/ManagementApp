using Application.Abstraction;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Queries.ChatQueries
{
    public class GetPrivateChatHandler : IRequestHandler<GetPrivateChatQuery, Chat>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPrivateChatHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Chat> Handle(GetPrivateChatQuery request, CancellationToken cancellationToken)
        {
            var pairValue = Generator.CantorPairFunction(request.SenderId, request.ReceiverId);
            return await _unitOfWork.ChatRepository.GetByPrivatePair(pairValue);
        }
    }
}
