namespace Domain.Entities
{
    public class CoreTeamPosition
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }

        public CoreTeamPosition( string name)
        {
            Name = name;
        }
    }
}
