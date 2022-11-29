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
        public List<User> Members { get; set; }
        public User Admin { get; private set; }

        public Team(int id, string name, User admin)
        {
            Id = id;
            Name = name;
            Admin = admin;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name:{Name}\nAdmin:{Admin.Name}\nCreatedAt:{CreatedAt}";
        }
    }
}
