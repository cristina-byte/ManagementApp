using Domain.OportunityEntities;
using MediatR;


namespace Application.Queries.OportunityQueries
{
    public class GetOportunityQuery:IRequest<Oportunity>
    {
        public int Id;
    }
}
