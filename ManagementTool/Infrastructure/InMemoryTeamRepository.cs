using Application.Abstraction;
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
                new Team("Internship"),
                new Team("Interns"),
                new Team("Amdaris")
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
