namespace Domain.Entities
{
   public class Chat
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<User> Participants { get; set; }
        public List<Message> Messages { get; set; }

        public Chat(int id, string name, List<User> participants)
        {
            Id = id;
            Name = name;
            Participants = participants;
            Messages = new List<Message>();
        }
    }
}
