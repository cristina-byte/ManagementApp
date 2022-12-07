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

        public async Task ChangePassword(int id, string password)
        {
            var member = await _context.Users.FindAsync(id);
            member.Password = password;
        }

        public async Task Create(User member)
        {
           await _context.Users.AddAsync(member);
        }

        public async Task Delete(int id)
        {
            var member = await _context.Users.FindAsync(id);
            _context.Users.Remove(member);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetMembers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(int id, User member)
        {
            throw new NotImplementedException();
        }

        
    }
}
