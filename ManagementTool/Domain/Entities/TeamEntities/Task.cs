
using System.Text.Json.Serialization;

namespace Domain.Entities.TeamEntities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public ICollection<UserTask> AssignedTo { get; set; }
        public Boolean isDone { get; set; }

        [JsonIgnore]
        public ToDo ToDo { get; set; }
    }
}
