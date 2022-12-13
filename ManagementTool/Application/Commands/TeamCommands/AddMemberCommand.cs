using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class AddMemberCommand:IRequest
    {
        public int TeamId { get; set; }
        public int UserId { get; set;}
    }
}
