using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.EventQueries
{
    public class GetEventsOrganizedByUserQuery:IRequest<IEnumerable<Event>>
    {
        public int UserId { get; set; }
    }
}
