using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Domain.Entities;

namespace Infrastructure
{
    public class InMemoryTeamRepository : ITeamRepository
    {
        private readonly List<Team> _teams;

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

        public void DeleteTeam(Team team)
        {
            _teams.Remove(team);
        }

        public Team GetByName(string name)
        {
            return _teams.Find(t => t.Name.Equals(name));
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }

        public void UpdateTeam(Team team)
        {
            
        }
    }
}
