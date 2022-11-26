using Domain.Entities;


namespace Application.Abstraction
{
    public interface IMemberRepository
    {
        public void Create(User member);
        public void Update(User member);
        public void Delete(User member);
        public User GetById(int id);
        public IEnumerable<User> GetMembers();
    }
}
