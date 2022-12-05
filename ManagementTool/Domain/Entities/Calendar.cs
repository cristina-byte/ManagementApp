
namespace Domain.Entities
{
    public class Calendar
    {
        public int Id { get; private set; }
        public User Member { get; set; }
        public int MemberId { get; set; }
        public ICollection<Meeting> Meetings { get; set; }

        public Calendar(int id)
        {
            Id = id;
            Meetings = new List<Meeting>();
        }
    }
}
