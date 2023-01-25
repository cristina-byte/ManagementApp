using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMemberRepository
    {
        public Task CreateAsync(User member);
        public Task UpdateAsync(int id,User member);
        public Task ChangePasswordAsync(int id,string password);
        public Task Delete(int id);
        public Task<User> GetByIdAsync(int id);
        public Task<int> GetMembersNumber();
        public Task<IEnumerable<User>> GetMembersAsync();
        public Task<string> GetPasswordAsync(int id);
        public Task<IEnumerable<User>> GetMembersPageAsync(int page);

    }
}
