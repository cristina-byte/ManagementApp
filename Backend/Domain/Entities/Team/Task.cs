using System.Text.Json.Serialization;

namespace Domain.TeamEntities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public ICollection<UserTask> AssignedTo { get; set; }
        public bool isDone { get; set; }

        [JsonIgnore]
        public ToDo ToDo { get; set; }
    }
}
