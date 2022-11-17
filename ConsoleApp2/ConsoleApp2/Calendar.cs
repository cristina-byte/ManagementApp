using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Calendar
    {
        private List<Meeting> _meetings;
        public List<Meeting> Meetings { get; set; }
       
        public Calendar()
        {
            _meetings = new List<Meeting>();
        }

        public void AddMeeting(Meeting meeting)
        {
            if (meeting == null)
                throw new ArgumentNullException("The given argument is null");
            _meetings.Add(meeting); 
        }

        public List<Meeting>GetMeetingsOn(DateTime date)
        {
            List<Meeting> schedualedMeetings=new List<Meeting>();
            foreach(Meeting meeting in _meetings)
                if(meeting.Date==date)
                    schedualedMeetings.Add(meeting);
            return schedualedMeetings ;
        }
    }
}
