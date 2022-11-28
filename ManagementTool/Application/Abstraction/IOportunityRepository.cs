using Domain.Entities.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityRepository
    {
        public void Create(Oportunity oportunity);
        public void Update(int id,Oportunity oportunity);
        public void Delete(Oportunity oportunity);
        public Oportunity GetById(int id);
        public IEnumerable<Oportunity> GetAll();
    }
}
