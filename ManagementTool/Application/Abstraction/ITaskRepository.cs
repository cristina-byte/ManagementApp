using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface ITaskRepository
    {
        public Task<Task2> CreateAsync(Task2 task);
        public Task UpdateAsync(int id, Task2 task);
        public Task Delete(int id);
        public Task<IEnumerable<Task2>> GetAllAsync(int toDoId);
        public Task<IEnumerable<Task2>> GetAllForMemberAsync(int memberId);
    }
}
