using Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context,IEventRepository eventRepository, 
            IMeetingRepository meetingRepository, IMemberRepository memberRepository,IOportunityRepository oportunityRepository
            ,ITeamRepository teamRepository,IToDoRepository toDoRepository,ITaskRepository taskRepository,
            IChatRepository chatRepository,
            IMessageRepository messageRepository,IOportunityPositionRepository oportunityPositionRepository,ICoreTeamPositionRepository coreTeamPositionRepository)
        {
            Console.WriteLine("Hello from unit of work");
            _context = context;
            EventRepository = eventRepository;
            MeetingRepository = meetingRepository;
            MemberRepository = memberRepository;
            OportunityRepository = oportunityRepository;
            TaskRepository = taskRepository;
            TeamRepository = teamRepository;
            ToDoRepository = toDoRepository;
            ChatRepository = chatRepository;
            MessageRepository = messageRepository;
            OportunityPositionRepository = oportunityPositionRepository;
            CoreTeamPositionRepository = coreTeamPositionRepository;
        }

        public IEventRepository EventRepository { get; private set; }

        public IMeetingRepository MeetingRepository { get; private set; }

        public IMemberRepository MemberRepository { get; private set; }

        public IOportunityRepository OportunityRepository { get; private set; }

        public ITaskRepository TaskRepository { get; private set; }

        public ITeamRepository TeamRepository { get; private set; }

        public IToDoRepository ToDoRepository { get; private set; }
        
        public IChatRepository ChatRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }
        public IOportunityPositionRepository OportunityPositionRepository { get; private set; }
        public ICoreTeamPositionRepository CoreTeamPositionRepository { get; private set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
