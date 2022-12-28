using Domain.Entities.TeamEntities;
using Task = System.Threading.Tasks.Task;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface IToDoRepository
    {
        public Task<ToDo> CreateAsync(ToDo toDoItem);
        public Task UpdateAsync(int id, ToDo toDoItem);
        public Task Delete(int id);
        public Task<ToDo> GetAsync(int id);
        public Task<IEnumerable<ToDo>> GetAllAsync(int teamId);
    }
}
