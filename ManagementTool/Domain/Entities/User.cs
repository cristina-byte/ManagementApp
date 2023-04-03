using Domain.Entities.TeamEntities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User:IdentityUser<int>
    {
        public override int Id { get; set; }
        public Boolean IsOnline {  get; }
        public string? ImageLink { get; set; }
        public  string Name { get; set; }
        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<ChatMember> Conversations { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public ICollection<UserTask> Tasks { get; set; }    
        public ICollection<MeetingInvited> MeetingInvited { get; set; }
        public ICollection<OportunityApplicant> OportunitiyApplicants { get; set; }

    }
}
