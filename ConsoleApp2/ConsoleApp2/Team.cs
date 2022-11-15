using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Team
    {
        private string _name;
        private DateTime _createdAt;
        private List<User> _members;

        public List<User> Members
        {
            get { return _members; }
            set { _members = value; }
        }

        public Team(string name, DateTime createdAt)
        {
            _name=name;
            _createdAt = createdAt; 
        }

        public DateTime CreatedAt { 
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public string Name { 
            get { return _name; } 
            set { _name = value; }
        }

        public void AddMember(User user)
        {
            _members.Add(user);
        }

        public void DeleteMember(User user)
        {
           for(int i = 0; i < _members.Count; i++)
                if (_members[i] == user)
                    _members.Remove(user);
        }
    }
}
