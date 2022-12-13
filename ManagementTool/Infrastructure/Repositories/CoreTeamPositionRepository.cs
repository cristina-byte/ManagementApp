using Application.Abstraction;
using Domain.Entities;
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
    }
}
