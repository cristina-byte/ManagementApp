using Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.TeamEntities.Task;
using Task2 = System.Threading.Tasks.Task;
namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task2 Create( Task task)
        {
            _context.Tasks.Add(task);
        }

        public async Task2 Delete(int id)
        {
            var task= await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            _context.Tasks.Remove(task);
        }

        public async Task<IEnumerable<Task>> GetAll()
        {
            return await _context.Tasks.ToListAsync<Task>();
        }

        public async Task2 Update(int id,Task task)
        {
            throw new NotImplementedException();
        }
    }
}
