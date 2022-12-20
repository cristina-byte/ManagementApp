using Domain.Entities.OportunityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.OportunityQueries
{
    public class GetOportunityQuery:IRequest<Oportunity>
    {
        public int Id;
    }
}
