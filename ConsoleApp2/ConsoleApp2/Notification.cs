using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Notification
    {
        private User _responsible;
        private string _action;
        private DateTime _created;

        public Notification(User responsible, string action, DateTime created)
        {
            _responsible = responsible;
            _action = action;   
            _created = created;
        }

        public string Action { get; set; }

        public User Responsible { get; set; }

        public DateTime Created { get; set; }
    }
}
