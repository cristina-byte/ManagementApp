using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OportunityCommands
{
    public class AddOportunityPositionCommand:IRequest
    {
        public int OportunityId { get; set; }
        public string Name { get; set; }
        public int LeftSits { get; set; }

    }
}
