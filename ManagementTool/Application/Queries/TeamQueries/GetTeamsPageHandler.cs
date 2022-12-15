using Application.Abstraction;
using Domain.Entities.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTeamsPageHandler : IRequestHandler<GetTeamsPageQuery, IEnumerable<Team>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTeamsPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Team>> Handle(GetTeamsPageQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TeamRepository.GetPageAsync(request.Page);
        }
    }
}
