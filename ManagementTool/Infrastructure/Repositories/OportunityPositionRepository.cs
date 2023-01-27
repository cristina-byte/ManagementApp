using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OportunityPositionRepository : IOportunityPositionRepository
    {
        private readonly ApplicationContext _context;

        public OportunityPositionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
        }

        public async Task Delete(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(position);
        }

        public async Task Update(int positionId)
        {
            var position = await _context.Positions.FindAsync(positionId);
            position.LeftSits = position.LeftSits - 1;
        }
    }
}
