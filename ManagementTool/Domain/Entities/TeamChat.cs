using Domain.Entities.TeamEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeamChat : Chat
    {
        public Team Team { get; set; }
        public int TeamId { get; set; }

        public TeamChat(int id, string name) : base(id, name)
        {
        }


    }
}
