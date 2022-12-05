using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationContext _context;

        public MeetingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Meeting meeting)
        {
           await _context.Meetings.AddAsync(meeting);
        }

        public async Task Delete(int id)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(me => me.Id == id);
            _context.Meetings.Remove(meeting);
        }

        public async Task<Meeting> Get(int id)
        {
            return await _context.Meetings.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAll()
        {
            return await _context.Meetings.ToListAsync<Meeting>();
        }

        public async Task Update(int id, Meeting meeting)
        {
           throw new NotImplementedException();
        }
    }
}
