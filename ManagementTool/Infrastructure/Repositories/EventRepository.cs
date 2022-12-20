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

        public async Task<Event> CreateAsync(Event ev)
        {
           var task= await _context.Events.AddAsync(ev);
            return task.Entity;
        }

        public async Task Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            _context.Events.Remove(ev);
        }

        public async Task<Event> GetAsync(int id)
        {
            var e = await _context.Events.Include(ev => ev.CoreTeamPositions)
                .Where(ev => ev.Id == id).FirstAsync();
            return e;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        { 
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetInProcessPageAsync(int page)
        {
            DateTime date = DateTime.Now;
            return await _context.Events.Where(ev => ev.StartDate < date && ev.EndDate > date)
                .Skip((page - 1) * 3).Take(3).ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetUpcomingPageAsync(int page)
        {
            DateTime date = DateTime.Now;
            return await _context.Events.Where(ev => ev.StartDate > date)
                .Skip((page - 1) * 3).Take(3).ToListAsync();
        }

        public async Task UpdateAsync(int id, Event ev)
        {
            var evt = await _context.Events.FindAsync();
            evt.Name = ev.Name;
            evt.StartDate = ev.StartDate;
            evt.EndDate = ev.EndDate;
            evt.Description = ev.Description;
            evt.Address = ev.Address;
        }

        public async Task<IEnumerable<Event>> GetEventsPageAsync(int page)
        {
            return await _context.Events.Skip((page - 1) * 3).Take(3).ToListAsync();
        }

        
    }
}
