using Application.Abstraction;
using Domain.MeetingEntities;
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
            await _context.Meetings.AddAsync(meeting);
        }

        public async Task<IEnumerable<Meeting>> GetAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAsync(int userId,int month,int year)
        {
            return await _context.MeetingInviteds.Where(mI=>mI.UserId==userId)
                .Join(
                _context.Meetings,
                meetingInvited => meetingInvited.MeetingId,
                meeting => meeting.Id,
               (meetingInvited, meeting) => meeting).Include(meeting=>meeting.Organizator)
               .Where(m=>m.StartDate.Year==year && m.StartDate.Month==month).ToListAsync();
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _context.Meetings
                .Include(meeting => meeting.Organizator)
                .Include(meeting => meeting.MeetingInvited)
                .ThenInclude(mI => mI.User)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Meeting entity, int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            meeting.Title = entity.Title;
            meeting.Address = entity.Address;
            meeting.StartDate = entity.StartDate;
            meeting.EndDate = entity.EndDate;
        }

        public async Task DeleteAsync(int id)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(me => me.Id == id);
            _context.Meetings.Remove(meeting);
        }

        public async Task AddGuestsAsync(Meeting meeting,IEnumerable<int> guestsId)
        {
            var meetInv= new List<MeetingInvited>();

            foreach (var guest in guestsId)
            {
                var user = await _context.Users.FindAsync(guest);
                var meetingInvited = new MeetingInvited()
                {
                    Meeting = meeting,
                    User = user,
                };

                meetInv.Add(meetingInvited);
            }
            await _context.MeetingInviteds.AddRangeAsync(meetInv);
        }
    }
}
