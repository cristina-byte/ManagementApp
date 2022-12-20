
namespace Domain.Entities
{
    public class Event
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CoreTeamPosition> CoreTeamPositions { get; set; }

        public Event(string name,string description,string address,DateTime startDate, 
            DateTime endDate)
        {
            Name = name;
            Description = description;
            Address = address;
            StartDate = startDate;
            EndDate = endDate;
            CoreTeamPositions = new List<CoreTeamPosition>();
        }
    }
}
