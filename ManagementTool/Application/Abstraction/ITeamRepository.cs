using Domain.Entities;
using Domain.TeamEntities;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface ITeamRepository:IRepository<Team>,IReadOnlyRepository<Team>
    {
        Task UpdateAsync(int id, string name);
        Task<IEnumerable<User>> GetMembersAsync(int teamId);
        Task AddMemberAsync(int memberId, int teamId);
        Task<IEnumerable<Team>> GetAsync(int userId);
        Task<IEnumerable<ToDo>> GetTasksAsync(int teamId);
    }
}
