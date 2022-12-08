using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMeetingRepository
    {
        public Task Create(Meeting meeting);
        public Task Update(int id,Meeting meeting);
        public Task Delete(int id);
        public Task<Meeting> Get(int id);
        public Task<IEnumerable<Meeting>> GetAll();
    }
}
