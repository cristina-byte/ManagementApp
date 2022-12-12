using Domain.Entities.TeamEntities;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public Task Create(Team team);
        public Task UpdateName(int id, string name);
        public Task Delete(int id);
        public Task<Team> Get(int id);
        public Task<IEnumerable<Team>> GetAll();
        public Task AddMember(int memberId, int teamId);
    }
}
