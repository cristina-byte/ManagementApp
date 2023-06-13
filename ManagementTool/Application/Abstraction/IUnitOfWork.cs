namespace Application.Abstraction
{
   public interface IUnitOfWork
    {
        public IMeetingRepository MeetingRepository { get; }
        public IMemberRepository MemberRepository { get; }
        public IOportunityRepository OportunityRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public IToDoRepository ToDoRepository { get; }
        public IOportunityPositionRepository OportunityPositionRepository { get; }

        public Task SaveAsync();
    }
}
