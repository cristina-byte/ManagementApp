using Application.Abstraction;
using Domain.OportunityEntities;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetAvailableOportunitiesHandler : IRequestHandler<GetAvailableOportunitiesQuery, List<Oportunity>>
    {

        public readonly IUnitOfWork _unitOfWork;

        public GetAvailableOportunitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Oportunity>> Handle(GetAvailableOportunitiesQuery request, CancellationToken cancellationToken)
        {
            var oportunities = await _unitOfWork.OportunityRepository.GetAvailableOportunitiesAsync();
            return oportunities;
        }
    }
}
