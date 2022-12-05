using MediatR;
using Task = Domain.Entities.TeamEntities.Task;
using Task2 = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface ITaskRepository
    {
        public Task2 Create(Task task);
        public Task2 Update(int id, Task task);
        public Task2 Delete(int id);
        public Task<IEnumerable<Task>> GetAll();
    }
}
