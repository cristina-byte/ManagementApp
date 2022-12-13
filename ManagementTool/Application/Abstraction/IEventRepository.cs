using Domain.Entities;

namespace Application.Abstraction { 
    public interface IEventRepository
    {
        public Task CreateAsync(Event ev);
        public Task UpdateAsync(int id,Event ev);
        public Task Delete(int id);
        public Task<Event> GetAsync(int id);
        public Task<IEnumerable<Event>> GetAllAsync();
        public Task<IEnumerable<Event>> GetUpcomingAsync();
        public Task<IEnumerable<Event>> GetInProcessAsync();
    }
}
