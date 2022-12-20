using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TeamEntities
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public User Admin { get; set; }
        public ICollection<ToDo> ToDoList { get; set; }
        public Chat Chat { get; set; }

        public Team(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name:{Name}\nCreatedAt:{CreatedAt}";
        }
    }
}
