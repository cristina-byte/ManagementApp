using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp
{
    internal class Notification
    {
        public User Responsible;
        public string Action;
        public DateTime Created;

        public Notification(User responsible, string action, DateTime created)
        {
            Responsible = responsible;
            Action = action;   
            Created = created;
        }
    }
}
