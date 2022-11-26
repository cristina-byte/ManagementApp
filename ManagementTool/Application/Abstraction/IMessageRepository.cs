using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMessageRepository
    {
        public void Create(Message message);
        public IEnumerable<Message> GetAll();
        public IEnumerable<Message> GetAllSentOn(DateTime date);
    }
}
