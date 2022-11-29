using Domain.Entities.TeamEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TeamQueries
{
    public class GetTeamQuery : IRequest<Team>
    {
        public string Name { get; set; }
    }
}
