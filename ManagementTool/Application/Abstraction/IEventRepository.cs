using Domain.Entities;


namespace Application.Abstraction { 
    public interface IEventRepository
    {
        public void Create(Event ev);
        public void Update(int id,Event ev);
        public void Delete(Event ev);
        public Event GetById(int id);
        public IEnumerable<Event> GetAll();
    }
}
