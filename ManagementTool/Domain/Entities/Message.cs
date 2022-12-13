using System.Globalization;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public DateTime SentAt { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }
        public Chat Chat { get; set; }

        public Message(string content, DateTime sentAt)
        {
            Id = Id;
            Content = content;
            SentAt = sentAt;
        }

        public TimeSpan GetTimeByNow() => DateTime.Now - SentAt;   
    }
}
