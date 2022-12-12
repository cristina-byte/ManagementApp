using Domain.Entities;

namespace Application.Abstraction { 
    public interface IEventRepository
    {
        public Task Create(Event ev);
        public Task Update(int id,Event ev);
        public Task Delete(int id);
        public Task<Event> Get(int id);
        public Task<IEnumerable<Event>> GetAll();
        public Task<IEnumerable<Event>> GetUpcoming();
        public Task<IEnumerable<Event>> GetInProcess();
    }
}
