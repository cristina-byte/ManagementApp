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

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(user => user.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetMembersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetMembersNumber()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<IEnumerable<User>> GetMembersPageAsync(int page)
        {
            return await _context.Users.Skip((page - 1) * 5).Take(5).ToListAsync();
        }

        public async Task UpdateAsync(int id, User member)
        {
            var user = await _context.Users.FindAsync(id);
            user.ImageLink = member.ImageLink;
  
        }   
    }
}
