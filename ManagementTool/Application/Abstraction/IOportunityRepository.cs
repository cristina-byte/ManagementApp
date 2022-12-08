using Domain.Entities.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityRepository
    {
        public Task Create(Oportunity oportunity);
        public Task Update(int id,Oportunity oportunity);
        public Task Delete(int id);
        public Task<Oportunity> Get(int id);
        public Task<IEnumerable<Oportunity>> GetAll();
    }
}
