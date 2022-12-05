using Domain.Entities.TeamEntities;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface IToDoRepository
    {
        public Task Create(ToDo toDoItem);
        public Task Update(int id, ToDo toDoItem);
        public Task Delete(int id);
        public Task<IEnumerable<ToDo>> GetAll();
    }
}
