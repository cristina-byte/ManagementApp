using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMessageRepository
    {
        public Task CreateAsync(Message message);
        public Task<IEnumerable<Message>> GetAllAsync(int chatId);
        public Task<IEnumerable<Message>> GetAllSentOnAsync(DateTime date);
    }
}
