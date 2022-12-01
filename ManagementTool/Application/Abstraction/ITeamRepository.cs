using Domain.Entities.TeamEntities;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public void Create(Team team);
        public void Update(int id, Team team);
        public void Delete(int id);
        public Team Get(int id);
        public IEnumerable<Team> GetAll();
    }
}
