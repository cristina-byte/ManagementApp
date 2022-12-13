using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMeetingRepository
    {
        public Task CreateAsync(Meeting meeting);
        public Task UpdateAsync(int id,Meeting meeting);
        public Task Delete(int id);
        public Task<Meeting> GetAsync(int id);
        public Task<IEnumerable<Meeting>> GetAllAsync(int userId);
        public Task AddGuests(int meetingId,IEnumerable<int> guests);
    }
}
