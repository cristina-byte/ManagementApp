using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Project
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Members { get; set; }
        public List<Task> ToDo { get; set; }

        public Project(string name, DateTime created, User createdBy, List<User> members, List<Task> toDo)
        {
            Name = name;
            Created = created;
            CreatedBy = createdBy;
            Members = members;
            ToDo = toDo;
        }

        public void AddTask(Task task)
        {
            ToDo.Add(task);
        }
    }
}
