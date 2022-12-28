using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.MeetingQueries
{
    public class GetMeetingQuery:IRequest<Meeting>
    {
        public int Id { get; set; }
    }
}
