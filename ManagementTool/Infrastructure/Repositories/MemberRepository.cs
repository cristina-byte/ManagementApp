using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationContext _context;

        public MemberRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task ChangePasswordAsync(int id, string password)
        {
            var member = await _context.Users.FindAsync(id);
            member.Password = password;
        }

        public async Task CreateAsync(User member)
        {
           await _context.Users.AddAsync(member);
        }

        public async Task Delete(int id)
        {
            var member = await _context.Users.FindAsync(id);
            _context.Users.Remove(member);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(user => user.Id == id)
                .Include(user => user.CoreTeamPositions
                .Where(c => c.Event.EndDate < DateTime.Now))
                .ThenInclude(ctp => ctp.Event).FirstAsync();
        }

        public async Task<IEnumerable<User>> GetMembersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetMembersPageAsync(int page)
        {
            return await _context.Users.Skip((page - 1) * 6).Take(6).ToListAsync();
        }

        public async Task<User> GetMostActiveAsync()
        {
            var group = await _context.CoreTeamPositions.Include(c => c.User)
                .GroupBy(c => c.User.Id)
                .Select(c => new
                {
                    UserId = c.Key,
                    RolesNumber = c.Count()
                }).ToListAsync();

            var userId=group.Where(ob => ob.RolesNumber == group.Max(o => o.RolesNumber)).First().UserId;
            return await _context.Users.FindAsync(userId);    
        }

        public async Task<string> GetPasswordAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user.Password;
        }

        public async Task UpdateAsync(int id, User member)
        {
            var user = await _context.Users.FindAsync(id);
            user.ImageLink = member.ImageLink;
            user.Name = member.Name;
            user.Phone = member.Phone;
        }   
    }
}
