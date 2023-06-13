using Application.Abstraction;
using Domain.Entities;
using MediatR;

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
            var users = await _unitOfWork.OportunityRepository.GetOportunityApplicantsForPositionAsync(request.OportunityId, request.PositionId);
            return users;
        }
    }
}
