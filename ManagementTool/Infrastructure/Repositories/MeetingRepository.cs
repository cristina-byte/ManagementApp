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

        public async Task CreateAsync(Meeting meeting)
        {
            
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

        public async Task<IEnumerable<Meeting>> GetAllAsync(int userId)
        {
            return await _context.MeetingInviteds.Where(mI=>mI.UserId==userId).Join(
             _context.Meetings,
              meetingInvited => meetingInvited.MeetingId,
              meeting => meeting.Id,
               (meetingInvited, meeting) => meeting).ToListAsync();
        }

        public async Task UpdateAsync(int id, Meeting meeting)
        {
           throw new NotImplementedException();
        }

        public async Task AddGuests(int meetingId,IEnumerable<int> guests)
        {
            List<MeetingInvited> meetingInviteds = new List<MeetingInvited>();
            foreach(var guest in guests)
            {
                var meetingInvited = new MeetingInvited(guest, meetingId);
                meetingInviteds.Add(meetingInvited);
            }
            await _context.MeetingInviteds.AddRangeAsync(meetingInviteds);
        }
    }
}
