using Application.Abstraction;
using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetUserTeamsHandler : IRequestHandler<GetUserTeamsQuery, IEnumerable<Team>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserTeamsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Team>> Handle(GetUserTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _unitOfWork.TeamRepository.GetAsync(request.UserId);
            return teams;
        }
    }
}
