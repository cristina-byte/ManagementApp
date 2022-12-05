using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationContext _context;

        public TeamRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Team team)
        {
           _context.Teams.Add(team);
        }

        public async Task Delete(int id)
        {
            var team = await _context.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
            _context.Teams.Remove(team);
        }

        public async Task<Team> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync<Team>();
        }

        public async Task Update(int id, Team team)
        {
            throw new NotImplementedException();
        }
    }
}
