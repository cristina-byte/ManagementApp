using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ChatQueries
{
    public class GetChatsHandler : IRequestHandler<GetChatsCommand, IEnumerable<Chat>>
    {
        public Task<IEnumerable<Chat>> Handle(GetChatsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
