using Application.Abstraction;
using Domain.Entities;


namespace Infrastructure
{
    public class InMemoryMemberRepository : IMemberRepository
    {
        public List<User> Users { get; set; }

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
            return Users.Find(user => user.Cnp == id);
        }

        public IEnumerable<User> GetMembers()
        {
            return Users;
        }

        public void Update(User member)
        {
            
        }
    }
}
