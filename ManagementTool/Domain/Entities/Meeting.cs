
namespace Domain.Entities
{
    public class Meeting
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public Calendar Calendar { get; set; }
        public User Organizator { get; set; }

        public Meeting(string title, string address, DateTime date)
        {
            Title = title;
            Address = address;
            Date = date;
        }

        public override string ToString() => $"Title: Title \nAddress: Address \nDate: Date";
    }
}
