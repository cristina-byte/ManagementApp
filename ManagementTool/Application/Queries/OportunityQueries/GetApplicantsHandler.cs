using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.OportunityQueries
{
    public class GetApplicantsHandler : IRequestHandler<GetApplicantsQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicantsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetApplicantsQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.OportunityRepository.GetOportunityApplicantsForPosition(request.OportunityId, request.PositionId);
            return users;
        }
    }
}
