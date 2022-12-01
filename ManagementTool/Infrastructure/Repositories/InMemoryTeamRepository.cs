using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class InMemoryTeamRepository : ITeamRepository
    {
        private readonly ApplicationContext _context;

        public InMemoryTeamRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Team team)
        {
           _context.Teams.Add(team);
        }

        public void Delete(int id)
        {
            var team = _context.Teams.Where(t => t.Id == id).FirstOrDefault();
            _context.Teams.Remove(team);
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList<Team>();
        }

       

        public void Update(int id, string Name)
        {
            
        }
    }
}
