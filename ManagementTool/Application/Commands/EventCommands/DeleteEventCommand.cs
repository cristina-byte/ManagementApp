using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EventCommands
{
    public class DeleteEventCommand:IRequest
    {
        public int Id { get; set; }
    }
}
