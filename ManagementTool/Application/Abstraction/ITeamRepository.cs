using Domain.Entities;
using Domain.Entities.TeamEntities;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public Task CreateAsync(Team team);
        public Task UpdateNameAsync(int id, string name);
        public Task Delete(int id);
        public Task<Team> GetAsync(int id);
        public Task<ICollection<User>> GetMembersAsync(int teamId);
        public Task AddMemberAsync(int memberId, int teamId);
        public Task<IEnumerable<Team>> GetTeamsForUser(int userId);
    }
}
