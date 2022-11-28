

namespace Domain.Entities
{
    public class Meeting
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public List<User> Invited { get; set; }
        public List<User> Accepted { get; set; }

        public Meeting(int id,string title, string address, DateTime date)
        {
            Id = id;
            Title = title;
            Address = address;
            Date = date;
            Invited = new List<User>();
            Accepted = new List<User>();
        }

        public override string ToString() => $"Title: Title \nAddress: Address \nDate: Date";
    }
}
