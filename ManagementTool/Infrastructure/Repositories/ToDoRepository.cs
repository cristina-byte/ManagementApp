using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace Infrastructure.Repositories
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly ApplicationContext _context;

        public ToDoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ToDo> CreateAsync(ToDo toDoItem)
        {
            var task=await _context.ToDoLists.AddAsync(toDoItem);
            return task.Entity;
        }

        public async Task Delete(int id)
        {
            var toDo= await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            _context.Teams.Remove(toDo);
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync(int teamId)
        {
            return await _context.Teams.Where(team => team.Id == teamId)
                .SelectMany(team => team.ToDoList).Include(tD=>tD.Tasks)
                .ThenInclude(task=>task.AssignedTo).ToListAsync();
        }

        public async Task<ToDo> GetAsync(int id)
        {
            return await _context.ToDoLists.FindAsync(id);
        }

        public async Task UpdateAsync(int id, ToDo toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
