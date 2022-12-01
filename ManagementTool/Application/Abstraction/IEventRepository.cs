using Domain.Entities;

namespace Application.Abstraction { 
    public interface IEventRepository
    {
        public void Create(Event ev);
        public void Update(int id,Event ev);
        public void Delete(int id);
        public Event Get(int id);
        public IEnumerable<Event> GetAll();
    }
}
