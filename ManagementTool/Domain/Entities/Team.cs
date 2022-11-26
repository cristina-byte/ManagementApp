using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<User> Members { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public void AddMember(User user)
        {
            Members.Add(user);
        }

        public void DeleteMember(User user)
        {
            for (int i = 0; i < Members.Count; i++)
                if (Members[i] == user)
                    Members.Remove(user);
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
