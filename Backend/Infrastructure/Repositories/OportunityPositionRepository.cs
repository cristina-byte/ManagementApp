using Application.Abstraction;
using Domain.OportunityEntities;

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

        public async Task DeleteAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(position);
        }

        public async Task DecrementAvailableSpotsAsync(int positionId)
        {
            var position = await _context.Positions.FindAsync(positionId);
            position.LeftSits = position.LeftSits - 1;
        }

        public Task UpdateAsync(Position entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
