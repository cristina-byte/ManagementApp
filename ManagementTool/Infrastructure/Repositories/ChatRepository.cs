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

        public async Task CreateAsync(Chat chat)
        {
            await _context.Conversations.AddAsync(chat);
        }

        public async Task Delete(int id)
        {
            var chat = await _context.Conversations.FindAsync(id);
            _context.Conversations.Remove(chat);
        }

        public Task<IEnumerable<Chat>> GetChatsAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
