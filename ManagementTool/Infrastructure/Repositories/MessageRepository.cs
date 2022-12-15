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

        public async Task CreateAsync(Message message)
        {
          await _context.Messages.AddAsync(message); 
        }

        public async Task<IEnumerable<Message>> GetAllAsync(int chatId)
        {
            return _context.Chats.Where(chat => chat.Id == chatId).SelectMany(chat => chat.Messages);
        }

        public async Task<IEnumerable<Message>> GetAllSentOnAsync(DateTime date)
        {
            return await _context.Messages.Where(m => m.SentAt.Year == date.Year 
            && m.SentAt.Month == date.Month && m.SentAt.Day == date.Day).ToListAsync<Message>();
        }
    }
}
