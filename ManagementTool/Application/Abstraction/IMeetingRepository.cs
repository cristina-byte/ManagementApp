using Domain.Entities;


namespace Application.Abstraction
{
    public interface IMeetingRepository
    {
        public void Create(Meeting meeting);
        public void Update(Meeting meeting);
        public void Delete(Meeting meeting);
        public Meeting GetById(int id);
        public IEnumerable<Meeting> GetAll();
    }
}
