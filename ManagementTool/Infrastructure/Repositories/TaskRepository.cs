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
            var t=await _context.Tasks.AddAsync(task);
        }

        public async Task Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
        }

        public Task<IEnumerable<Task2>> GetAllAsync(int toDoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task2>> GetAllForMemberAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, Boolean isDone)
        {
            var task=await _context.Tasks.FindAsync(id);
            task.isDone = isDone;
            
        }

    }
}
