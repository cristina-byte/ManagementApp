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

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Where(user => user.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<int> GetNumberAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<IEnumerable<User>> GetPageAsync(int page)
        {
            return await _context.Users.Skip((page - 1) * 5).Take(5).ToListAsync();
        }

        public async Task UpdateAsync(string photoLink, int id)
        {
            var user = await _context.Users.FindAsync(id);
            user.ImageLink = photoLink;
        }
    }
}
