using Application.Abstraction;
using Domain.OportunityEntities;
using MediatR;

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
            return await _unitOfWork.OportunityRepository.GetByIdAsync(request.Id);
        }
    }
}
