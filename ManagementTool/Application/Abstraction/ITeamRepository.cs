using Domain.Entities.TeamEntities;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public void Create(Team team);
        public void UpdateTeam(Team team);
        public void DeleteTeam(Team team);
        public Team GetByName(string name);
        public IEnumerable<Team> GetTeams();
    }
}
