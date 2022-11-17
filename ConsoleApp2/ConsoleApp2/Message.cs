using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Message
    {
        public DateTime Sent { get; set; }
        public string Text { get; set; }
        public User Destination { get; set; }

        public Message(string text, DateTime sent, User destination)
        {
            Text = text;
            Sent = sent;
            Destination = destination;
        }

        public TimeSpan GetTimeByNow() => DateTime.Now - Sent;

        public override string ToString()
        {
            TimeSpan interval = GetTimeByNow();
            string time;

            if (interval.Days<1)
            {
                if (interval.Hours<1)
                {
                    if (interval.Minutes<1)
                    {
                        time = interval.Seconds.ToString() + " seconds";
                    }
                    else { time = interval.Minutes.ToString() + " minutes"; }
                }
                else { time = interval.Hours.ToString() + " hours"; }
            }
            else { time = interval.Days.ToString() + " days"; }

            return $"time ago \nMessage:{Text} \nSent at: {new DateTimeOffset(Sent).ToString()} " +
                   $"\nSent to:{ Destination.Name} \nSent from:{ CultureInfo.CurrentCulture.DisplayName}" +
                   $" \nTime zone: { TimeZone.CurrentTimeZone.StandardName}";
        }
    }
}
 