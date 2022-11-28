using Application.Abstraction;
using Infrastructure;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Teams
            ITeamRepository teamRepository = new InMemoryTeamRepository();
            var teams = teamRepository.GetAll();

            foreach(var team in teams)
            {
                Console.WriteLine($"Name:{team.Name} \nAdmin:{team.Admin.Name}");
            }


        }
    }
}