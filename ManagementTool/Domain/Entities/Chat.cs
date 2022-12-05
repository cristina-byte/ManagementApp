namespace Domain.Entities
{
   public class Chat
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public ICollection<ChatMember> Participants { get; set; }
        public ICollection<Message> Messages { get; set; }

        public Chat(int id, string name)
        {
            Id = id;
            Name = name;
            Participants = new List<ChatMember>();
            Messages = new List<Message>();
        }
    }
}
