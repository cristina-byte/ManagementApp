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
        protected string _name;
        protected string _password;
        protected string _email;
        protected BigInteger _phone;
        protected BigInteger _cnp;
        protected DateTime _birthDay;
        protected List<Message> _sentMessages;
        protected List<Message> _receivedMessages;

        public User(string name,string password,string email, BigInteger phone,BigInteger cnp, DateTime birthDay){
           _sentMessages = new List<Message>();
           _receivedMessages = new List<Message>();
           _name= name;
           _password= password;
           _email= email;
           _phone= phone;
           _cnp= cnp;  
           _birthDay= birthDay;
        }
      
        public List<Message> SentMessages{
            get{
                return _sentMessages;
            }
            set{
                _sentMessages = value;
            }
        }

        public string Name {
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }

        public string Email{
            get{
                return _email;
            }
            set{
                _email= value;
            }
        }

        public string Password { 
            get { return _password; }
            set { _password = value; }
        }
       
        public override string ToString() => "This is a simple user" + "\n" + "Name:" + _name + "\nEmail:" + _email + "\nPhone:" + _phone + "\nBorned at:" + _birthDay + "\nCnp:" + _cnp;

        public static User Authentificate(string password,string email,List<User> users){
            foreach (User user in users)
                if (user.Password.Equals(password) && user.Email.Equals(email))
                    return user;
            return null;
        }

        public static void Authentificate(string email){
            Console.WriteLine("Authentification using a google account");
        }

        public void SendMessage(Message message){
            _sentMessages.Add(message);
        }

        public List<Message> searchInConversions(string text){
            List<Message> messages = new List<Message>();
            foreach(Message message in _sentMessages){
                string[] words = message.Text.Split(' ');
                foreach(string word in words)
                    if(word.Equals(text))
                        messages.Add(message); 
            }
            return messages;
        }
    }
}
