using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class EditTaskStatusCommand:IRequest
    {
        public int TaskId { get; set; }
        public Boolean IsDone { get; set; }

    }
}
