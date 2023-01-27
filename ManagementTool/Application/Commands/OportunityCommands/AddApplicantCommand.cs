using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.OportunityCommands
{
    public class AddApplicantCommand:IRequest
    {
        public int OportunityId { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
    }
}
