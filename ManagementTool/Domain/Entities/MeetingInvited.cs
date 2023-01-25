using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MeetingInvited
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

        public MeetingInvited(int userId,int meetingId)
        {
            UserId = userId;
            MeetingId = meetingId;
        }

        public MeetingInvited() { }
    }
}
