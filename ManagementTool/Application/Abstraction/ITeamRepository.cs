using Domain.Entities.TeamEntities;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public void Create(Team team);
        public void Update(int id, Team team);
        public void Delete(Team team);
        public Team GetByName(string name);
        public IEnumerable<Team> GetTeams();
    }
}
