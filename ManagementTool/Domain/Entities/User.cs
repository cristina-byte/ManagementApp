
using Domain.Entities.TeamEntities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Task = Domain.Entities.TeamEntities.Task;

namespace Domain.Entities
{
    public class User:IdentityUser<int>
    {
        public int Id { get;set; }
        public Boolean IsOnline { get; set; }
        public string? ImageLink { get; set; }
        public  string Name { get; set; }
        public string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<ChatMember> Conversations { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public ICollection<UserTask> Tasks { get; set; }    
        public ICollection<MeetingInvited> MeetingInvited { get; set; }

     
        public User(string userName,string name, string phone,DateTime birthDay)
        {
            UserName = userName;
            Name = name;
            PhoneNumber = phone;
            BirthDay = birthDay;
            Email = userName;
        }

        public User() { }

        public User(string imageLink) {
            ImageLink = imageLink;
        
        }


    }
}
