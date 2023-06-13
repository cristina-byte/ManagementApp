using Domain.Entities;
using Domain.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityRepository:IRepository<Oportunity>,IEnumerableRepository<Oportunity>,IReadOnlyRepository<Oportunity>
    {
        public Task AddApplicantAsync(int oportunityId, int userId,int positionId);
        public Task<List<User>> GetOportunityApplicantsForPositionAsync(int oportunityId, int positionId);
        public Task<List<Oportunity>> GetAvailableOportunitiesAsync();
    }
}
