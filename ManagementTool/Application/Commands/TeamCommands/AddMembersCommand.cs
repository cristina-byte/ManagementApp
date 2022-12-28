using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class AddMembersCommand:IRequest
    {
        public int TeamId { get; set; }
        public ICollection<int> UsersId { get; set;}
    }
}
