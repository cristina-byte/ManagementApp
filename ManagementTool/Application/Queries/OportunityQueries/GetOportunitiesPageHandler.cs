using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetOportunitiesPageHandler:IRequestHandler<GetOportunitiesPageQuery,IEnumerable<Oportunity>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOportunitiesPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Oportunity>> Handle(GetOportunitiesPageQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.OportunityRepository.GetOportunitiesPageAsync(request.Page);
        }
    }
}
