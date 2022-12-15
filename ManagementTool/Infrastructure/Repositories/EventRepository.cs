using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);  
        }

        public async Task Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            _context.Events.Remove(ev);
        }

        public async Task<Event> GetAsync(int id)
        {
            var e = await _context.Events.FindAsync(id);
            return e;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        { 
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetInProcessAsync()
        {
            DateTime date = DateTime.Now;
            return await _context.Events.Where(ev => ev.StartDate < date && ev.EndDate > date).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingAsync()
        {
            DateTime date = DateTime.Now;
            return await _context.Events.Where(ev => ev.StartDate > date).ToListAsync();
        }

        public async Task UpdateAsync(int id, Event ev)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetEventsPageAsync(int page)
        {
            return await _context.Events.Skip((page - 1) * 3).Take(3).ToListAsync();
        }

        
    }
}
