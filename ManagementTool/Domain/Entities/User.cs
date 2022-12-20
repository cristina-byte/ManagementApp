using Domain.Entities.OportunityEntities;
using Domain.Entities.TeamEntities;
using Task = Domain.Entities.TeamEntities.Task;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cnp { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<ChatMember> Conversations { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public ICollection<UserTask> Tasks { get; set; }    
        public ICollection<CoreTeamPosition> CoreTeamPositions { get; set; } 
        public ICollection<MeetingInvited> MeetingInvited { get; set; }

      
        public User(string name, string password, string email, string phone, 
            string cnp, DateTime birthDay)
        {
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            Cnp = cnp;
            BirthDay = birthDay;
        }

        public User(string name,string phone,
            string cnp, DateTime birthDay)
        {
            Name = name;
            Phone = phone;
            Cnp = cnp;
            BirthDay = birthDay;
        }

        public override string ToString() => $"\nName:{Name} \nEmail:{Email} \nPhone:{Phone} " +
            $"\nBorned at:{BirthDay} \nCnp:{Cnp}";

        public static User Authentificate(string email, string password, List<User> users)
        {
            foreach (User user in users)
                if (user.Password.Equals(password) && user.Email.Equals(email))
                    return user;
            return null;
        }

        public static void Authentificate(string email)
        {
            Console.WriteLine("Authentification using a google account");
        }
    }
}
