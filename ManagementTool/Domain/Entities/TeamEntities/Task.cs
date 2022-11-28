using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TeamEntities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public List<User> AssignedTo { get; set; }
        public string Status { get; set; }

        public Task(int id, string title, List<User> assignedTo, string status)
        {
            Id = id;
            Title = title;
            AssignedTo = assignedTo;
            Status = status;
        }
    }
}
