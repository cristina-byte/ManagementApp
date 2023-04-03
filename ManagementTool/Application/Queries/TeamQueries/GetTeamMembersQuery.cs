using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TeamQueries
{
    public class GetTeamMembersQuery:IRequest<ICollection<User>>
    {
        public int TeamId { get; set; }
    }
}
