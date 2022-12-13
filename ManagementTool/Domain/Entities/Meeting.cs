
namespace Domain.Entities
{
    public class Meeting
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User Organizator { get; set; }
        public ICollection<MeetingInvited> MeetingInvited { get; set; }

        public Meeting(string title, string address, DateTime startDate,DateTime endDate)
        {
            Title = title;
            Address = address;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString() => $"Title: Title \nAddress: Address \nDate: Date";
    }
}
