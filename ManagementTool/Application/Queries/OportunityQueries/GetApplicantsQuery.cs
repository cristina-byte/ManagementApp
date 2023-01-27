using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.OportunityQueries
{
    public class GetApplicantsQuery:IRequest<List<User>>
    {
        public int OportunityId { get; set; }
        public int PositionId { get; set; }

    }
}
