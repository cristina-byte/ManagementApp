namespace Domain.TeamEntities

{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public Team Team { get; set; }

    }
}
