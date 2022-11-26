using Domain.Entities;


namespace Application.Abstraction
{
    public interface IOportunityRepository
    {
        public void Create(Oportunity oportunity);
        public void Update(Oportunity oportunity);
        public void Delete(Oportunity oportunity);
        public Oportunity GetById(int id);
        public IEnumerable<Oportunity> GetAll();
    }
}
