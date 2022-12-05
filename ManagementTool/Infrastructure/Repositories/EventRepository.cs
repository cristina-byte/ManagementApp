using Application.Abstraction;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Event ev)
        {
            _context.Events.Add(ev);
        }

        public void Delete(int id)
        {
            var ev = _context.Events.Where(e => e.Id == id).FirstOrDefault();
            _context.Events.Remove(ev);
        }

        public Event Get(int id)
        {
            return _context.Events.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public void Update(int id, Event ev)
        {
            _context.Events.Where(e => e.Id == id).Select(e => ev);
        }
    }
}
