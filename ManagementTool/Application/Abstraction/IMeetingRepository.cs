using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMeetingRepository
    {
        public void Create(Meeting meeting);
        public void Update(int id,Meeting meeting);
        public void Delete(int id);
        public Meeting Get(int id);
        public IEnumerable<Meeting> GetAll();
    }
}
