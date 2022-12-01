using Application.Abstraction;
using Task = Domain.Entities.TeamEntities.Task;
namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create( Task task)
        {
            _context.Tasks.Add(task);
        }

        public void Delete(int id)
        {
            var task= _context.Tasks.FirstOrDefault(t => t.Id == id);
            _context.Tasks.Remove(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _context.Tasks.ToList<Task>();
        }

        public void Update(int id,Task task)
        {
            throw new NotImplementedException();
        }
    }
}
