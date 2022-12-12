using Application.Abstraction;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Task2 task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task2>> GetAllAsync(int toDoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task2>> GetAllForMemberAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Task2 task)
        {
            throw new NotImplementedException();
        }
    }
}
