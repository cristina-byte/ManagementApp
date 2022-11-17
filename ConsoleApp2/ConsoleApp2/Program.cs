using System.Numerics;
using System.Xml;

namespace ConsoleApp2
{
    internal class Program
    {
        public static  List<User> Users=new List<User>();
        public static User AuthentificatedUser { get; set; }
       
        static void Main(string[] args)
        {

            //Add some users
            Users.Add(new User("cristinasiscanu30@gmail.com", "hardware"));
            Users.Add(new Admin("iontutu@gmail.com", "mypassword"));
            Users.Add(new Admin("anamaria@gmail.com", "ana56"));

            AuthentificatedUser =User.Authentificate("iontutu@gmail.com", "mypassword",Users);

            //Send messages
            AuthentificatedUser.SendMessage(new Message("Hello my friend!", new DateTime(2022,11,9,10,23,12), Users[0]));
            AuthentificatedUser.SendMessage(new Message("Hello Ana!", new DateTime(2022, 11, 17,14,00,04), Users[2]));
            AuthentificatedUser.SendMessage(new Message("Hello, did you finish your assignement?", new DateTime(2022, 11, 17,14,2,00), Users[2]));

            //Print messages sent on some date
            AuthentificatedUser.PrintMessagesSentOn(new DateTime(2022, 11, 17));

           
            //Print messages that contain a secific word
            List<Message> messages=AuthentificatedUser.SearchInConversions("hellO");
            Console.WriteLine("\nMessages that contain a specific word\n");
            Console.WriteLine(string.Join('\n',messages));


            //Change Password
            AuthentificatedUser.ChangePassword("newPassword", "newPassword");
        }
    }
}