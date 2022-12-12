using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationContext _context;

        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(Message message)
        {
          await _context.Messages.AddAsync(message); 
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetAllSentOn(DateTime date)
        {
            return await _context.Messages.Where(m => m.SentAt.Year == date.Year 
            && m.SentAt.Month == date.Month && m.SentAt.Day == date.Day).ToListAsync<Message>();
        }
    }
}
