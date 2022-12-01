using Application.Abstraction;
using Domain.Entities.TeamEntities;

namespace Infrastructure.Repositories
{
    public class ToDoRepository:IToDoRepository
    {
        private readonly ApplicationContext _context;

        public ToDoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(ToDo toDoItem)
        {
            _context.ToDoLists.Add(toDoItem);
        }

        public void Delete(int id)
        {
            var toDo=_context.Teams.FirstOrDefault(t => t.Id == id);
            _context.Teams.Remove(toDo);
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _context.ToDoLists.ToList<ToDo>();
        }

        public void Update(int id, ToDo toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
