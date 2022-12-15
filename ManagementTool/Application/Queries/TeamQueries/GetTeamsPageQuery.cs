using Domain.Entities.TeamEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TeamQueries
{
    public class GetTeamsPageQuery:IRequest<IEnumerable<Team>>
    {
        public int Page { get; set; }
    }
}
