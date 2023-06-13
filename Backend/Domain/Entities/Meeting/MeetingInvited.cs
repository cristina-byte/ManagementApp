using Domain.Entities;

namespace Domain.MeetingEntities

{
    public class MeetingInvited
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

    }
}
