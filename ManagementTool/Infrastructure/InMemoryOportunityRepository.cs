using Application.Abstraction;
using Domain.Entities.Oportunity;

namespace Infrastructure
{
    public class InMemoryOportunityRepository : IOportunityRepository
    {
        public List<Oportunity> Oportunities { get; set; }

        public InMemoryOportunityRepository()
        {
         Oportunities=new List<Oportunity>();
        }

        public void Create(Oportunity oportunity)
        {
            Oportunities.Add(oportunity);
        }

        public void Delete(Oportunity oportunity)
        {
            Oportunities.Remove(oportunity);
        }

        public IEnumerable<Oportunity> GetAll()
        {
            return Oportunities;
        }

        public Oportunity GetById(int id)
        {
            return Oportunities.Where(oportunity => oportunity.Id == id).First();

        }

        public void Update(int id,Oportunity oportunity)
        {
            Oportunities.Where(oportunity => oportunity.Id == id).ToList<Oportunity>().ForEach(op => op = oportunity);
        }
    }
}
