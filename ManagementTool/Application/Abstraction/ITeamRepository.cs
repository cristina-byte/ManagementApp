using Domain.Entities.TeamEntities;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public void Create(Team team);
        public void UpdateName(int id, string Name);
        public void Delete(Team team);
        public Team GetByName(string name);
        public IEnumerable<Team> GetAll();
    }
}
