using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CoreTeamPositionRepository : ICoreTeamPositionRepository
    {
        private readonly ApplicationContext _context;
        public CoreTeamPositionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CoreTeamPosition position)
        {
            await _context.CoreTeamPositions.AddAsync(position);
        }

        public async Task<IEnumerable<CoreTeamPosition>> GetAll(int userId)
        {
            return await _context.Users.Where(user => user.Id == userId)
                 .SelectMany(user => user.CoreTeamPositions)
                 .Include(c => c.Event).ToListAsync();
        }
    }
}
