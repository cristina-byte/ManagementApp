using Domain.Entities;

namespace Application.Abstraction
{
    public interface IToDoRepository
    {
        public void Create(ToDo toDoItem);
        public void Update(ToDo toDoItem);
        public void Delete(ToDo toDoItem);
        public IEnumerable<ToDo> GetAll();
    }
}
