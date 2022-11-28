using Domain.Entities.TeamEntities;

namespace Application.Abstraction
{
    public interface IToDoRepository
    {
        public void Create(ToDo toDoItem);
        public void Update(int id, ToDo toDoItem);
        public void Delete(ToDo toDoItem);
        public IEnumerable<ToDo> GetAll();
    }
}
