using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; private set; }
        public DateTime SentAt { get; set; }
        public string Content { get; set; }
        public User Sender { get; set; }

        public Message(string content, DateTime sentAt, User sender)
        {
            Id = Id;
            Content = content;
            SentAt = sentAt;
            Sender = sender;
        }

        public TimeSpan GetTimeByNow() => DateTime.Now - SentAt;

        public override string ToString()
        {
            TimeSpan interval = GetTimeByNow();
            string time;

            if (interval.Days < 1)
            {
                if (interval.Hours < 1)
                {
                    if (interval.Minutes < 1)
                    {
                        time = interval.Seconds.ToString() + " seconds";
                    }
                    else { time = interval.Minutes.ToString() + " minutes"; }
                }
                else { time = interval.Hours.ToString() + " hours"; }
            }
            else { time = interval.Days.ToString() + " days"; }

            return $"{time} ago \nMessage:{Content} \nSent at: {new DateTimeOffset(SentAt).ToString()} " +
                   $"\nSent to:{Sender.Email} \nSent from:{CultureInfo.CurrentCulture.DisplayName}" +
                   $" \nTime zone: {TimeZone.CurrentTimeZone.StandardName}";
        }
    }
}
