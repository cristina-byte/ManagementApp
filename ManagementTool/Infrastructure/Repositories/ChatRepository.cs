using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repositories
{
    public class ChatRepository:IChatRepository
    {

        private readonly ApplicationContext _context;

        public ChatRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddParticipantAsync(int userId, int chatId)
        {
            var chatMember = new ChatMember
            {
                UserId=userId, 
                ChatId=chatId 
            };

            await _context.ChatMembers.AddAsync(chatMember);
        }

        public async Task<Chat> CreateAsync(Chat chat)
        {
            var c=await _context.Chats.AddAsync(chat);
            return c.Entity;
        }

        public async Task Delete(int id)
        {
            var chat = await _context.Chats.FindAsync(id);
            _context.Chats.Remove(chat);
        }

        public async Task<IEnumerable<Chat>> GetChatsAsync(int userId)
        {
            return await _context.Users.Where(user => user.Id == userId).SelectMany(user => user.Conversations)
                .Include(c => c.Chat)
                .Select(c => c.Chat).Where(c=>c.PrivatePair!=null).ToListAsync();
        }

        public async Task<Chat> GetByPrivatePair(int value)
        {
            return await _context.Chats
                .Where(c => c.PrivatePair != null && c.PrivatePair == value).FirstOrDefaultAsync();
        }

        public async Task<Chat> GetById(int id)
        {
            var chat = await _context.Chats.Where(chat => chat.Id == id)
                .Include(chat => chat.Participants).ThenInclude(participant => participant.User)
                .Include(chat => chat.Messages).
                ThenInclude(message => message.Sender).FirstAsync();
            return chat;
        } 
    }
}
