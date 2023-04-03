
namespace Domain.Entities.TeamEntities
{
    public class Team
    {
        public int Id { get; private set; }
        public string? ImageLink { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public User Admin { get; set; }
        public ICollection<ToDo> ToDoList { get; set; }
        public Chat? Chat { get; set; }

    }
}
