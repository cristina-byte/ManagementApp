using Domain.Entities.TeamEntities;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface ITeamRepository
    {
        public Task Create(Team team);
        public Task Update(int id, Team team);
        public Task Delete(int id);
        public Task<Team> Get(int id);
        public Task<IEnumerable<Team>> GetAll();
    }
}
