
namespace Application.Abstraction
{
   public interface IUnitOfWork:IDisposable
    {
        public IEventRepository EventRepository { get; }
        public IMeetingRepository MeetingRepository { get; }
        public IMemberRepository MemberRepository { get; }
        public IOportunityRepository OportunityRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public IToDoRepository ToDoRepository { get; }
        public IChatRepository ChatRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IOportunityPositionRepository OportunityPositionRepository { get; }
        public ICoreTeamPositionRepository CoreTeamPositionRepository { get; }

        public Task Save();
    }
}
