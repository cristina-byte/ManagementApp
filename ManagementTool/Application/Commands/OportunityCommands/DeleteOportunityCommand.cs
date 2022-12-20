using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OportunityCommands
{
    public class DeleteOportunityCommand:IRequest
    {
        public int Id { get; set; }
    }
}
