using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMemberRepository
    {
        public Task UpdateAsync(int id,User member);
        public Task<User> GetByIdAsync(int id);
        public Task<int> GetMembersNumber();
        public Task<IEnumerable<User>> GetMembersAsync();
        public Task<IEnumerable<User>> GetMembersPageAsync(int page);

    }
}
