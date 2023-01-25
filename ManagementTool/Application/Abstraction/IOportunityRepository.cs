using Domain.Entities.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityRepository
    {
        public Task<Oportunity> CreateAsync(Oportunity oportunity);
        public Task UpdateAsync(int id,Oportunity oportunity);
        public Task Delete(int id);
        public Task<int> GetOportunitiesNumber();
        public Task<Oportunity> GetAsync(int id);
        public Task<IEnumerable<Oportunity>> GetAllAsync();
        public Task<IEnumerable<Oportunity>> GetOportunitiesPageAsync(int page);
    }
}
