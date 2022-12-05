using Application.Abstraction;
using Domain.Entities;


namespace Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public List<User> Users { get; set; }
        public ApplicationContext Context { get; private set; }

        public MemberRepository(ApplicationContext context)
        {
            Context = context;
        }

        public async Task Create(User member)
        {
            Users.Add(member);
        }

        public async Task Delete(User member)
        {
            Users.Remove(member);
        }

        public async Task<User> GetById(int id)
        {
            return Users.Find(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetMembers()
        {
            return Users;
        }

        public void Update(int id, User member)
        {
            throw new NotImplementedException();
        }
    }
}
