using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Calendar
    {
        public int Id { get; private set; }
        public List<Meeting> Meetings { get; set; }

        public Calendar(int id)
        {
            Id = id;
            Meetings = new List<Meeting>();
        }
    }
}
