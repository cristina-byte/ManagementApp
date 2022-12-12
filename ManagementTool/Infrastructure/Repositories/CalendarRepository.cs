using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly ApplicationContext _context;

        public CalendarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Calendar calendar)
        {
            await _context.AddAsync(calendar);
        }

        public async Task<Calendar> Get(int userId)
        {
            return await _context.Calendars.Where(c => c.MemberId == userId).FirstAsync();
        }
    }
}
