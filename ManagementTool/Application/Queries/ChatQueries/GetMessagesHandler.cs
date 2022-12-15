using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ChatQueries
{
    public class GetMessagesHandler : IRequestHandler<GetMessagesQuery, IEnumerable<Message>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMessagesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Message>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MessageRepository.GetAllAsync(request.ChatId);
        }
    }
}
