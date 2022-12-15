using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UsersQueries
{
    public class GetMostActiveMemberHandler : IRequestHandler<GetMostActiveMemberQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMostActiveMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetMostActiveMemberQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MemberRepository.GetMostActiveAsync();
        }
    }
}
