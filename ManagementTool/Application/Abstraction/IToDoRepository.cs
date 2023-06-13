using Domain.TeamEntities;

namespace Application.Abstraction
{
    public interface IToDoRepository:IRepository<ToDo>,IReadOnlyRepository<ToDo>
    {
        public Task<IEnumerable<ToDo>> GetAsync(int teamId);
    }
}
