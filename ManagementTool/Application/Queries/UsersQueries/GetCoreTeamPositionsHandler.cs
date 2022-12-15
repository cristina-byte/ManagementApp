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
    public class GetCoreTeamPositionsHandler : IRequestHandler<GetCoreTeamPositionsQuery, IEnumerable<CoreTeamPosition>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetCoreTeamPositionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CoreTeamPosition>> Handle(GetCoreTeamPositionsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CoreTeamPositionRepository.GetAll(request.UserId);
        }
    }
}
