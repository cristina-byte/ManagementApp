using Application.Abstraction;
using Domain.Entities;


namespace Infrastructure.Repositories
{
    public class InMemoryMemberRepository : IMemberRepository
    {
        public List<User> Users { get; set; }
        public ApplicationContext Context { get; private set; }

        public InMemoryMemberRepository(ApplicationContext context)
        {
            Context = context;
        }

        public void Create(User member)
        {
            Users.Add(member);
        }

        public void Delete(User member)
        {
            Users.Remove(member);
        }

        public User GetById(int id)
        {
            return Users.Find(user => user.Id == id);
        }

        public IEnumerable<User> GetMembers()
        {
            return Users;
        }

        public void Update(int id, User member)
        {

        }
    }
}
