namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Member> users = new List<Member>();
            users.Add(new Intern("Cristina Siscanu", 22, 1234321234563, DateTime.Parse("01/11/2022")));
            users.Add(new Mentor("Ion Ceban", 34, 5678945678904,new Intern("Maria Tirsina", 25, 1234321234563, DateTime.Parse("01/11/2022"))));
            users.Add(new Intern("Elena Ciumeica", 25, 1234321234563, DateTime.Parse("01/11/2022")));
            users.Add(new Mentor("Valeria Murdeala", 34, 5432167890456, null));

            foreach (Member user in users)
            {
                Console.WriteLine(user);
            }



        }
    }
}