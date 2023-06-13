using Application.Abstraction;
using Domain.TeamEntities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repositories
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly ApplicationContext _context;

        public ToDoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ToDo toDoItem)
        {
            await _context.ToDoLists.AddAsync(toDoItem);
        }

        public async Task DeleteAsync(int id)
        {
            var toDo = await _context.ToDoLists.FindAsync(id);
            _context.ToDoLists.Remove(toDo);
        }

        public async Task<IEnumerable<ToDo>> GetAsync(int teamId)
        {
            var toDoList = await _context.ToDoLists
              .Include(td => td.Team)
              .Where(td => td.Team.Id == teamId).ToListAsync();
            return toDoList;
        }

        public Task<IEnumerable<ToDo>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            return await _context.ToDoLists.FindAsync(id);
        }

        public async Task UpdateAsync(ToDo entity, int id)
        {
            var toDo = await _context.ToDoLists.FindAsync(id);
            toDo.Name = entity.Name;
        }
    }
}
