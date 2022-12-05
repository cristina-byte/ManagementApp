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
            Console.WriteLine("You are in the create method");
            _context.Events.Add(ev);
            Console.WriteLine("The event was added");
            _context.SaveChanges();  
        }

        public async Task Delete(int id)
        {
            var ev = await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
            _context.Events.Remove(ev);
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
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
