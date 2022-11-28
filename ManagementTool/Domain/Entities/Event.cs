using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CoreTeamPosition> CoreTeam { get; set; }

        public Event(int id,string name,string description,string address,DateTime startDate, 
            DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            StartDate = startDate;
            EndDate = endDate;
            CoreTeam = new List<CoreTeamPosition>();
        }
    }
}
