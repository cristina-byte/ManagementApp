using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Event
    {
        private string _name;
        private DateTime _date;
        private string _address;
        private string _description;
        private List<User> _invited;
        private List<User> _accepted;
        private List<User> _rejected;

        public Event(string name, DateTime date, string address, string description, List<User> invited, List<User> accepted, List<User> rejected)
        {
            _name = name;
            _date = date;
            _address = address;
            _description = description;
            _invited = invited;
            _accepted = accepted;
            _rejected = rejected;
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string Description { get; set; } 
    }
}
