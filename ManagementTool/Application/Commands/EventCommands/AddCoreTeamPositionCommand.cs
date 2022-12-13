using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EventCommands
{
    public class AddCoreTeamPositionCommand:IRequest
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
