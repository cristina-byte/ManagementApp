using Domain.Entities;

namespace Application.Abstraction
{
    public interface INotificationRepository
    {
        public void Create(Notification notification);
        public IEnumerable<Notification> GetAll();
        public void Delete(Notification notification);
    }
}
