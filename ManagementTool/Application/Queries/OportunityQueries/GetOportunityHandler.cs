using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.OportunityQueries
{
    public class GetOportunityHandler : IRequestHandler<GetOportunityQuery, Oportunity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOportunityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Oportunity> Handle(GetOportunityQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.OportunityRepository.GetAsync(request.Id);
        }
    }
}
