using Domain.OportunityEntities;
using MediatR;

namespace Application.Queries.OportunityQueries
{
    public class GetAvailableOportunitiesQuery:IRequest<List<Oportunity>>
    {


    }
}
