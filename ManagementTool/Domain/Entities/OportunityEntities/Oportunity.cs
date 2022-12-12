
namespace Domain.Entities.OportunityEntities
{
    public class Oportunity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public ICollection<Position> Positions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }

        public Oportunity(string title, string description,
              DateTime startDate, DateTime endDate, string location)
        {
            Title = title;
            CreatedAt = DateTime.Now;
            Description = description;
            Positions = new List<Position>();
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
        }
    }
}
