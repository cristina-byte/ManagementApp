using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Team
    {
        private string name;
        private DateTime createdAt;
        private List<User> members;

        public List<User> Members
        {
            get { return members; }
            set { members = value; }
        }

        public Team(string _name, DateTime _createdAt)
        {
            name=_name;
            createdAt = _createdAt;
            
        }

        public DateTime CreatedAt { 
            get { return createdAt; }
            set { createdAt = value; }
        }
        public string Name { 
            get { return name; } 
            set { name = value; }
        }
    }
}
