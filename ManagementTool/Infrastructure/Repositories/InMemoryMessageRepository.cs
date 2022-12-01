using Application.Abstraction;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class InMemoryMessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _context;

        public InMemoryMessageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Message message)
        {
           _context.Messages.Add(message); 
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList<Message>();
        }

        public IEnumerable<Message> GetAllSentOn(DateTime date)
        {
            return _context.Messages.Where(m => m.SentAt.Year == date.Year 
            && m.SentAt.Month == date.Month && m.SentAt.Day == date.Day).ToList<Message>();
        }
    }
}
