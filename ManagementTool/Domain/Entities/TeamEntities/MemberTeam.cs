namespace Domain.Entities.TeamEntities
{
    public class MemberTeam
    {
        public int MemberId { get; set; }
        public User Member { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public MemberTeam(int memberId,int teamId)
        {
            MemberId = memberId;
            TeamId = teamId;
        }

    }
}
