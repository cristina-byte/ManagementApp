using Domain.Entities.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityRepository
    {
        public Task CreateAsync(Oportunity oportunity);
        public Task UpdateAsync(int id,Oportunity oportunity);
        public Task Delete(int id);
        public Task<Oportunity> GetAsync(int id);
        public Task<IEnumerable<Oportunity>> GetAllAsync();
    }
}
