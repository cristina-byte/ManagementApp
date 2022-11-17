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
            try
            {
                string email, password;
                Console.WriteLine("Log In:");
                Console.WriteLine("Email:");
                email = Console.ReadLine();
                if (email == null)
                    throw new ArgumentNullException("The argument email is null");
                Console.WriteLine("Password:");
                password = Console.ReadLine();
                if(password == null)    
                    throw new ArgumentNullException("The argument password is null");
                _authentificatedUser = User.Authentificate(password, email, _users);
                Console.WriteLine("User " + _authentificatedUser.Name + " was authentificated!");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Authentification failed");
            }
        }

        static User GetUserByEmail(string email){
            
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
                            Console.WriteLine("6. Print all users");
                            Console.WriteLine("7. Print messages sent on some date");
                            Console.WriteLine("9. Log out");


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

                                    try
                                    {
                                        message = Console.ReadLine();
                                        if (message == null)
                                            throw new ArgumentNullException("The argument message is null");
                                        Console.WriteLine("The email of person you want to send the message:");
                                        email = Console.ReadLine();
                                        if (email == null)
                                            throw new ArgumentNullException("The argument email is null");
                                        User destination = GetUserByEmail(email);
                                        if (destination != null)
                                            _authentificatedUser.SendMessage(new Message(message, DateTime.Now, destination));
                                    }

                                    catch (ArgumentNullException ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                    break;

                                case 4:
                                    foreach(Message msg in _authentificatedUser.SentMessages)
                                        Console.WriteLine(msg.ToString());
                                    break;

                                case 5:
                                    string word;
                                    Console.WriteLine("Type the word");
                                    word = Console.ReadLine();
                                    try
                                    {
                                        List<Message> messages = _authentificatedUser.searchInConversions(word);
                                        Console.WriteLine("Messages taht contain the word " + word);
                                        foreach (Message m in messages)
                                            Console.WriteLine(m.ToString());
                                    }
                                    catch(ArgumentNullException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine(string.Join('\n',_users));
                                    break;

                                case 7:
                                    try {
                                        _authentificatedUser.prinMessagesSentOn(new DateTime(2023, 12, 4));
                                    }

                                    catch(InvalidDateException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }                                  
                                    break;
                            }

                        } while (select != 9);
                        break;
                  
                    case 2:break;  
                } 
            } while (option != 2);
        }
    }
}