using Application.Abstraction;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context,
            IMeetingRepository meetingRepository, IMemberRepository memberRepository,
            IOportunityRepository oportunityRepository,ITeamRepository teamRepository,
            IToDoRepository toDoRepository,ITaskRepository taskRepository,
            IOportunityPositionRepository oportunityPositionRepository)
        {
            _context = context;
            MeetingRepository = meetingRepository;
            MemberRepository = memberRepository;
            OportunityRepository = oportunityRepository;
            TaskRepository = taskRepository;
            TeamRepository = teamRepository;
            ToDoRepository = toDoRepository;
            OportunityPositionRepository = oportunityPositionRepository;
        }

        public IMeetingRepository MeetingRepository { get; private set; }
        public IMemberRepository MemberRepository { get; private set; }
        public IOportunityRepository OportunityRepository { get; private set; }
        public ITaskRepository TaskRepository { get; private set; }
        public ITeamRepository TeamRepository { get; private set; }
        public IToDoRepository ToDoRepository { get; private set; }
        public IOportunityPositionRepository OportunityPositionRepository { get; private set; }
   
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
