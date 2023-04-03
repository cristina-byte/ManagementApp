
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
       
        public bool isBetweenDates(DateTime date1, DateTime date2)
        {
            var date= new DateTime(this.StartDate.Year,this.StartDate.Month,this.StartDate.Day);

            if (DateTime.Compare(date,date1)>=0 && DateTime.Compare(date, date2) <= 0)
                return true;
            return false;
        }
    }
}
