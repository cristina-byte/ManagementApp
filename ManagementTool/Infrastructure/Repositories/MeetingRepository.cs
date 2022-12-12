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

        public async Task CreateAsync(Calendar calendar, Meeting meeting)
        {
            meeting.Calendar = calendar;
            await _context.AddAsync(meeting);
        }

        public async Task Delete(int id)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(me => me.Id == id);
            _context.Meetings.Remove(meeting);
        }

        public async Task<Meeting> GetAsync(int id)
        {
            return await _context.Meetings.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAllAsync(int calendarId)
        {
            //get the calendar object
            var c = await _context.Calendars.FindAsync(calendarId);

            return await _context.Meetings.Join(
                _context.Calendars,
                meeting => meeting.Calendar.Id,
                calendar => calendar.Id,
                (meeting, calendar) => meeting).ToListAsync();
        }

        public async Task UpdateAsync(int id, Meeting meeting)
        {
           throw new NotImplementedException();
        }
    }
}
