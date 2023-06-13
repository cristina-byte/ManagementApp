using Application.Abstraction;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetOportunitiesNumberHandler : IRequestHandler<GetOportunitiesNumberQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOportunitiesNumberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(GetOportunitiesNumberQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.OportunityRepository.GetNumberAsync();
        }
    }
}
