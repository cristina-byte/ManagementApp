using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.MeetingCommands
{
    public class CreateMeetingCommand:IRequest
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int CalendarId { get; set; }
        public int UserId { get; set; }
    }
}
