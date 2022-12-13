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
    public class GetChatsHandler : IRequestHandler<GetChatsQuery, IEnumerable<Chat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetChatsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Chat>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
