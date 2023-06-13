using Application.Abstraction;
using Domain.Entities;
using Domain.OportunityEntities;
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

        public async Task AddApplicantAsync(int oportunityId, int userId,int positionId)
        {
            var oportunityApplicant = new OportunityApplicant
            {
                UserId=userId,
                OportunityId=oportunityId,
                PositionId=positionId 
            };
            await _context.OportunityApplicants.AddAsync(oportunityApplicant); 
        }

        public async Task CreateAsync(Oportunity oportunity)
        {
            await _context.Oportunities.AddAsync(oportunity);
        }

        public async Task DeleteAsync(int id)
        {
            var oportunity = await _context.Oportunities.Where(op => op.Id == id)
                .FirstOrDefaultAsync();
            _context.Oportunities.Remove(oportunity);
        }

        public async Task <IEnumerable<Oportunity>> GetAsync()
        {
            return await _context.Oportunities.ToListAsync();
        }

        public async Task<Oportunity> GetByIdAsync(int id)
        {
            return await _context.Oportunities.Where(op => op.Id == id)
                .Include(op=>op.Positions).FirstOrDefaultAsync();
        }

        public async Task<List<Oportunity>> GetAvailableOportunitiesAsync()
        {
            var oportunities = await _context.Oportunities
                .Include(op => op.Positions)
                .Where(op => op.ApplicationDeadline > DateTime.Now && op.Positions
                .Where(p => p.LeftSits > 0).Count() > 0)
                .Take(5).ToListAsync();
            return oportunities;
        }

        public async Task<int> GetNumberAsync()
        {
            return await _context.Oportunities.CountAsync();
        }

        public async Task<IEnumerable<Oportunity>> GetPageAsync(int page)
        {
            return await _context.Oportunities.OrderByDescending(op=>op.CreatedAt).Skip((page - 1) * 3).Take(3).ToListAsync();
        }

        public async Task<List<User>> GetOportunityApplicantsForPositionAsync(int oportunityId, int positionId)
        {
            var users = await _context.OportunityApplicants.Include(op=>op.User)
                .Where(op => op.OportunityId == oportunityId && op.PositionId == positionId)
                .Select(op=>op.User)
                .ToListAsync();

            return users;
        }

        public async Task UpdateAsync(Oportunity oportunity, int id )
        {
            var op = await _context.Oportunities.FindAsync(id);
            op.Title = oportunity.Title;
            op.Location = oportunity.Location;
            op.StartDate = oportunity.StartDate;
            op.EndDate = oportunity.EndDate;
            op.ImageLink = oportunity.ImageLink;
            op.ApplicationDeadline = oportunity.ApplicationDeadline;
            op.Description = oportunity.Description;
            op.Positions = oportunity.Positions;
        }
    }
}
