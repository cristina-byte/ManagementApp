using Domain.Entities;


namespace Application.Abstraction
{
    public interface IMemberRepository
    {
        public Task Create(User member);
        public Task Update(int id,User member);

        public Task ChangePassword(int id,string password);
        public Task Delete(int id);
        public Task<User> GetById(int id);
        public Task<IEnumerable<User>> GetMembers();
    }
}
