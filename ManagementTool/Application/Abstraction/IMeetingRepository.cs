using Domain.Entities;


namespace Application.Abstraction
{
    public interface IMeetingRepository
    {
        public void Create(Meeting meeting);
        public void Update(int id,Meeting meeting);
        public void Delete(Meeting meeting);
        public Meeting GetById(int id);
        public IEnumerable<Meeting> GetAll();
    }
}
