using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public BigInteger Phone { get; set; }
        public BigInteger Cnp { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }

        public User(string name,string password,string email, BigInteger phone,BigInteger cnp, DateTime birthDay)
        {
           SentMessages = new List<Message>();
           ReceivedMessages = new List<Message>();
           Name= name;
           Password= password;
           Email= email;
           Phone= phone;
           Cnp= cnp;  
           BirthDay= birthDay;
        }

        public User(string email,string password)
        {
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
            Email = email;
            Password = password;
        }
     
        public override string ToString() => $"\nName:{Name} \nEmail:{Email} \nPhone:{Phone} \nBorned at:{BirthDay} \nCnp:{Cnp}";

        public static User Authentificate(string email,string password,List<User> users)
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

        public void SendMessage(Message message)
        {
            SentMessages.Add(message);
        }

        public void PrintMessagesSentOn(DateTime date)
        {
            if (DateTime.Now < date)
                throw new InvalidDateException("The action can't be done on this date");

            foreach(Message message in SentMessages)
            {
                if (message.Sent.Year==date.Year && message.Sent.Month==date.Month && message.Sent.Day==date.Day)
                    Console.WriteLine($"\n{message.ToString()}");
            }
        }

        public void ChangePassword(string newPassword,string confirmedPassword)
        {
            if (newPassword.Equals(confirmedPassword))
            {
                Password = newPassword;
            }
        }

        public List<Message> SearchInConversions(string text)
        {
            if(text==null)
                throw new ArgumentNullException("The argument text is null");

            List<Message> messages = new List<Message>();
            foreach(Message message in SentMessages)
            {
                string[] words = message.Text.Split(' ');

                foreach(string word in words)
                    if(word.Equals(text,StringComparison.CurrentCultureIgnoreCase))
                        messages.Add(message); 
            }
            return messages;
        }
    }
}
