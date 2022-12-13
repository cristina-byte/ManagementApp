using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var chatMember = new ChatMember(userId, chatId);
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
            return await _context.Chats.GroupJoin(
                _context.Teams,
                chat => chat.Id,
                team => team.Chat.Id,
                (c, t) => new
                {
                    chat = c,
                    team = t
                }).Where(ob => ob.team != null).Select(ob => ob.chat).ToListAsync();
        }

        public async Task<Chat> GetByPrivatePair(int value)
        {
            return await _context.Chats.Where(c => c.PrivatePair != null && c.PrivatePair == value).FirstAsync();
        }

        public async Task<Chat> Get(int id)
        {
            return await _context.Chats.FindAsync(id);
        }
    }
}
