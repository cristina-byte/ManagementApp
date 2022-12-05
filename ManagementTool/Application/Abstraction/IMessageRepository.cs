using Domain.Entities;
using MediatR;

namespace Application.Abstraction
{
    public interface IMessageRepository
    {
        public Task Create(Message message);
        public Task<IEnumerable<Message>> GetAll();
        public Task<IEnumerable<Message>> GetAllSentOn(DateTime date);
    }
}
