using Domain.MeetingEntities;

namespace Application.Abstraction
{
    public interface IMeetingRepository:IRepository<Meeting>,IReadOnlyRepository<Meeting>
    {
        Task<IEnumerable<Meeting>> GetAsync(int userId,int month,int year);
        public Task AddGuestsAsync(Meeting meeting,IEnumerable<int> guests);
    }
}
