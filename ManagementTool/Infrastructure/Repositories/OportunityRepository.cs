using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OportunityRepository : IOportunityRepository
    {
        private readonly ApplicationContext _context;

        public OportunityRepository(ApplicationContext context)
        {
            _context= context;
        }

        public async Task CreateAsync(Oportunity oportunity)
        {
            await _context.Oportunities.AddAsync(oportunity); 
        }

        public async Task Delete(int id)
        {
            var oportunity = await _context.Oportunities.Where(op => op.Id == id).FirstOrDefaultAsync();
            _context.Oportunities.Remove(oportunity);
        }

        public async Task <IEnumerable<Oportunity>> GetAllAsync()
        {
            return await _context.Oportunities.ToListAsync<Oportunity>();
        }

        public async Task<Oportunity> GetAsync(int id)
        {
            return await _context.Oportunities.Where(op => op.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateAsync(int id, Oportunity oportunity)
        {
            throw new NotImplementedException();
        }
    }
}
