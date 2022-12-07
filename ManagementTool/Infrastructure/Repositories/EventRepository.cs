using Application.Abstraction;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;


namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Event ev)
        {
            await _context.Events.AddAsync(ev); 
        }

        public async Task Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            _context.Events.Remove(ev);
        }

        public async Task<Event> Get(int id)
        { 
            var ev = await _context.Events.FindAsync(id);
            return ev;
        }

        public async Task<IEnumerable<Event>> GetAll()
        { 
            return await _context.Events.ToListAsync();
        }

        public async Task Update(int id, Event ev)
        {
            throw new NotImplementedException();
        }
    }
}
