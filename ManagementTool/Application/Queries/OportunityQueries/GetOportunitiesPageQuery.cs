using Domain.Entities.OportunityEntities;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetOportunitiesPageQuery:IRequest<IEnumerable<Oportunity>>
    {
        public int Page { get; set; }
    }
}
