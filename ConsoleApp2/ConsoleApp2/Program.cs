namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User("Cristina Siscanu", "mypassword", "cristinasiscanu30@gmail.com", 0749292012, 3422110987658, DateTime.Parse("15/04/2000")));
            users.Add(new User("Ana Cebanu", "password456", "ana.ceban@gmail.com", 0949396012, 3409874567898, DateTime.Parse("20/09/1998")));
            users.Add(new Admin("Ion Tutu", "pppy&8881", "ion.tutu@gmail.com", 074097826, 9000756789734, DateTime.Parse("12/02/2001")));

            foreach(User user in users)
            {
                Console.WriteLine(user.ToString());
            }

            users[0].Authentificate("cristinasiscanu30@gmail.com");
            users[1].Authentificate("mypassword", "cristinasiscanu30@gmail.com");

        }
    }
}