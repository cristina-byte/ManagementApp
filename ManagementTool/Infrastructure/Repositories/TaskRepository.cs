using Application.Abstraction;
using Task2 = Domain.TeamEntities.Task;

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
            var t=await _context.Tasks.AddAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
        }

        public async Task UpdateAsync(Task2 entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, bool status)
        {
            var task = await _context.Tasks.FindAsync(id);
            task.isDone = status;
        }
    }
}
