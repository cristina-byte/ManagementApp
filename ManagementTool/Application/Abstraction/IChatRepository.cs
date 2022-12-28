using Domain.Entities;
using Domain.Entities.TeamEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstraction
{
    public interface IChatRepository
    {
        public Task<IEnumerable<Chat>> GetChatsAsync(int userId);
        public Task<Chat> CreateAsync(Chat chat);
        public Task Delete(int id);
        public Task<Chat> GetByPrivatePair(int value);
        public Task<Chat> GetById(int id);
        public Task AddParticipantAsync(int userId, int chatId);
    }
}
