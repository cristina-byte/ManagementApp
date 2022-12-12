using Domain.Entities.TeamEntities;
using Task = System.Threading.Tasks.Task;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface IToDoRepository
    {
        public Task Create(ToDo toDoItem);
        public Task Update(int id, ToDo toDoItem);
        public Task Delete(int id);
        public Task<ToDo> GetById(int id);
        public Task<IEnumerable<ToDo>> GetAll();
    }
}
