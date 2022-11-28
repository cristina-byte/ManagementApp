namespace Domain.Entities
{
    public class CoreTeamPosition
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public User Responsible { get; set; }

        public CoreTeamPosition(int id, string name, User responsible)
        {
            Id = id;
            Name = name;
            Responsible = responsible;
        }
    }
}
