using Domain.Entities;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetApplicantsQuery:IRequest<List<User>>
    {
        public int OportunityId { get; set; }
        public int PositionId { get; set; }

    }
}
