using Domain.Entities;

namespace Application.Abstraction { 
    public interface IEventRepository
    {
        public Task<Event> CreateAsync(Event ev);
        public Task UpdateAsync(int id,Event ev);
        public Task Delete(int id);
        public Task<Event> GetAsync(int id);
        public Task<IEnumerable<Event>> GetAllAsync();
        public Task<IEnumerable<Event>> GetUpcomingPageAsync(int page);
        public Task<IEnumerable<Event>> GetInProcessPageAsync(int page);
        public Task<IEnumerable<Event>> GetEventsPageAsync(int page);
    }
}
