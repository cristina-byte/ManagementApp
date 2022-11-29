using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Domain.Entities;

namespace Infrastructure
{
    public class InMemoryTeamRepository : ITeamRepository
    {
        private readonly List<Team> _teams;
        public ApplicationContext Context { get; private set; }

        public InMemoryTeamRepository()
        {
            _teams = new List<Team>()
            {
                new Team(1,"Internship",new User(1,"Cristina Siscanu")),
                new Team(2,"Interns",new User(2,"Ion Tutu")),
                new Team(3,"Amdaris",new User(1,"Cristina Siscanu"))
            };
        }

        public void Create(Team team)
        {
            _teams.Add(team);
        }

        public void Delete(Team team)
        {
            _teams.Remove(team);
        }

        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }

        public Team GetByName(string name)
        {
            return _teams.Find(t => t.Name.Equals(name));
        }

        public void UpdateName(int id, string Name)
        {
            _teams.Where(t => t.Id == id).ToList<Team>().ForEach(t => t.Name = Name);
        }
    }
}
