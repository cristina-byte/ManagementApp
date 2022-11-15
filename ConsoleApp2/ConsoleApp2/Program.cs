using System.Numerics;
using System.Xml;

namespace ConsoleApp2
{
    internal class Program
    {
        public static  List<User> _users=new List<User>();
        public static User _authentificatedUser;
       
      

        static void LogIn()
        {
            string email, password;
            Console.WriteLine("Log In:");
            Console.WriteLine("Email:");
            email = Console.ReadLine();
            Console.WriteLine("Password:");
            password = Console.ReadLine();
            _authentificatedUser = User.Authentificate(password, email,_users);
            if (_authentificatedUser != null)
                Console.WriteLine("User " + _authentificatedUser.Name + " was authentificated!");
            else
                Console.WriteLine("Authentification failed");
        }

        static User getUserByEmail(string email){
            foreach (User user in _users)
                if (user.Email.Equals(email))
                    return user;
            return null;
        }

        static void Main(string[] args){
            int option = 0;
            //add users
            _users.Add(new User("Cristina Siscanu", "hardware", "cristinasiscanu30@gmail.com", 0749292012, 0986789067890, new DateTime(2000,4,15)));
            _users.Add(new User("Ion Tutu", "mypassword", "iontutu@gmail.com", 074896712, 1234543215678, new DateTime(1994, 3, 10)));

            do{
                Console.WriteLine("\n1.Log in your account");
                Console.WriteLine("2.Iesire");
                Console.WriteLine("\nChoose an option:");
                option = Int32.Parse(Console.ReadLine());

                switch (option){
                    case 1:
                        int select;
                        LogIn();
                        do{
                            Console.WriteLine("\n1. View your user information");
                            Console.WriteLine("2. Create a team");
                            Console.WriteLine("3. Send a message");
                            Console.WriteLine("4. View all messages ");
                            Console.WriteLine("5. View messages that contain a specific word");
                            Console.WriteLine("6. Log out");
                           
                            Console.WriteLine("\nChoose an option:");
                            select = Int32.Parse(Console.ReadLine());

                            switch (select){
                                case 1:
                                    Console.WriteLine(_authentificatedUser.ToString());
                                    break;

                                case 3:
                                    string message;
                                    string email;
                                    Console.Write("Type the message:");
                                    message=Console.ReadLine();
                                    Console.WriteLine("The email of person you want to send the message:");
                                    email = Console.ReadLine();
                                    User destination = getUserByEmail(email);
                                    if(destination!=null)
                                    _authentificatedUser.SendMessage(new Message(message, DateTime.Now,destination));
                                    break;

                                case 4:
                                    foreach(Message msg in _authentificatedUser.SentMessages)
                                        Console.WriteLine(msg.ToString());
                                    break;


                                case 5:
                                    string word;
                                    Console.WriteLine("Type the word");
                                    word = Console.ReadLine();
                                    Console.WriteLine("Messages taht contain the word "+word);
                                    List<Message> messages=_authentificatedUser.searchInConversions(word);
                                    foreach(Message m in messages)
                                        Console.WriteLine(m.ToString());
                                    break;
                            }

                        } while (select != 6);
                        break;
                  
                    case 2:break;  
                } 
            } while (option != 7);
        }
    }
}