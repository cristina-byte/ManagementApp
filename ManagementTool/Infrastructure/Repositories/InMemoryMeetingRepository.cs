using Application.Abstraction;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class InMemoryMeetingRepository : IMeetingRepository
    {
        private readonly ApplicationContext _context;

        public InMemoryMeetingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
        }

        public void Delete(int id)
        {
            var meeting = _context.Meetings.FirstOrDefault(me => me.Id == id);
            _context.Meetings.Remove(meeting);
        }

        public Meeting Get(int id)
        {
            return _context.Meetings.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _context.Meetings.ToList<Meeting>();
        }

        public void Update(int id, Meeting meeting)
        {
           _context.Meetings.Where(m => m.Id == id).Select(m => meeting);
        }
    }
}
