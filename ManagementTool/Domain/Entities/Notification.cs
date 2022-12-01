using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Notification
    {
        public int Id { get; private set; }
        public User Responsible { get;set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification(int id,User responsible, string action, DateTime created)
        {
            Id = id;
            Responsible = responsible;
            Action = action;
            CreatedAt = created;
        }
    }
}
