using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Project
    {
        private string _name;
        private DateTime _created;
        private User _createdBy;
        private List<User> _members;
        private List<Task> _toDo;

        public Project(string name, DateTime created, User createdBy, List<User> members, List<Task> toDo)
        {
            _name = name;
            _created = created;
            _createdBy = createdBy;
            _members = members;
            _toDo = toDo;
        }

        public void AddTask(Task task)
        {
            _toDo.Add(task);
        }
    }
}
