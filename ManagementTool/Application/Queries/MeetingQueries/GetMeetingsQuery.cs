using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingsQuery:IRequest<IEnumerable<Meeting>>
    {
        public int UserId { get; set; }
    }
}
