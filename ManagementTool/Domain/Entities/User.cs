using System.Numerics;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public BigInteger Phone { get; set; }
        public BigInteger Cnp { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Chat> Conversations { get; set; }
        

        public User(int id,string name, string password, string email, BigInteger phone, 
            BigInteger cnp, DateTime birthDay)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            Cnp = cnp;
            BirthDay = birthDay;
        }

        public User(int id,string name)
        {
            Id = id;
            Name = name;
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
