using Task2 = Domain.Entities.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface ITaskRepository
    {
        public Task Create(Task2 task);
        public Task Update(int id, Task2 task);
        public Task Delete(int id);
        public Task<IEnumerable<Task2>> GetAll(int toDoId);
        public Task<IEnumerable<Task2>> GetAllForMember(int memberId);

    }
}
