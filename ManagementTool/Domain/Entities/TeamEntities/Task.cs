
namespace Domain.Entities.TeamEntities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public ICollection<UserTask> AssignedTo { get; set; }
        public string Status { get; set; }
        public ToDo ToDo { get; set; }

        public Task(int id, string title,string status)
        {
            Id = id;
            Title = title;
            Status = status;
        }
    }
}
