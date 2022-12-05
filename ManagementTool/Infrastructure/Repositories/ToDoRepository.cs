using Application.Abstraction;
using Domain.Entities.TeamEntities;
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

        public async Task Create(ToDo toDoItem)
        {
            _context.ToDoLists.Add(toDoItem);
        }

        public async Task Delete(int id)
        {
            var toDo= await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            _context.Teams.Remove(toDo);
        }

        public async Task<IEnumerable<ToDo>> GetAll()
        {
            return await _context.ToDoLists.ToListAsync<ToDo>();
        }

        public async Task Update(int id, ToDo toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
