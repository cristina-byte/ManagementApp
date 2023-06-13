using Application.Abstraction;
using Domain.TeamEntities;
using MediatR;

namespace Application.Queries.TeamQueries
{
    public class GetTeamHandler : IRequestHandler<GetTeamQuery, Team>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTeamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> Handle(GetTeamQuery query, CancellationToken cancellationToken)
        {
            var team = await _unitOfWork.TeamRepository.GetByIdAsync(query.Id);
            return team;
        }
    }
}
