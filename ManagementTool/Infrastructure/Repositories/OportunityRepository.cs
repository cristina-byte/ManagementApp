using Application.Abstraction;
using Domain.Entities.OportunityEntities;

namespace Infrastructure.Repositories
{
    public class OportunityRepository : IOportunityRepository
    {
        private readonly ApplicationContext _context;

        public OportunityRepository(ApplicationContext context)
        {
            _context= context;
        }

        public void Create(Oportunity oportunity)
        {
            _context.Oportunities.Add(oportunity); 
        }

        public void Delete(int id)
        {
            var oportunity = _context.Oportunities.Where(op => op.Id == id).FirstOrDefault();
            _context.Oportunities.Remove(oportunity);
        }

        public IEnumerable<Oportunity> GetAll()
        {
            return _context.Oportunities.ToList<Oportunity>();
        }

        public Oportunity Get(int id)
        {
            return _context.Oportunities.Where(op => op.Id == id).FirstOrDefault();
        }

        public void Update(int id, Oportunity oportunity)
        {
            
        }
    }
}
