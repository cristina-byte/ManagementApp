using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Oportunity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public User PostedBy { get; set; }
        public string Description { get; set; }
        public User Organizer { get; set; }
        public List<Position> Positions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }

        public Oportunity(int id,string title, DateTime createdAt,User postedBy,string description,
            User organizer,List<Position> positions,DateTime startDate,DateTime endDate,string location)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            PostedBy = postedBy;
            Description = description;
            Organizer = organizer;
            Positions = positions;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
        }
    }
}
