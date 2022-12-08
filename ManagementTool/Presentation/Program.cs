using Application.Abstraction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using Application.Commands.EventCommands;
using Infrastructure;
using Application.Queries.EventQueries;
using Task = System.Threading.Tasks.Task;

namespace Presentation
{
    public class Program
    {
        private static IMediator _mediator;

        static  async void CreateEvent()
        {
          await _mediator.Send(new CreateEventCommand
            {
                Name = "Christmas Charity",
                Address = "FC Ripensia",
                Description = "Lets help children",
                StartDate = new DateTime(2022, 12, 12),
                EndDate = new DateTime(2022, 12, 14)
            });

            Console.WriteLine("You are after send method");
        }

        static async Task GetEventAsync()
        {
            var ev=await _mediator.Send(new GetEventQuery { Id = 1 }) ;
            Console.WriteLine(ev.Id + " "+ev.Name);
        }

        static  void Main(string[] args)
        {
            //get the mediator service
            _mediator = Init();
            GetEventAsync();
            Task.Delay(10000).Wait();
        }

        public static IMediator Init()
        {
            //define a container for dependency injection
            var iOContainer = new ServiceCollection()
               .AddMediatR(typeof(CreateEventCommand).Assembly)
               .AddDbContext<ApplicationContext>()
               .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
               .AddScoped(typeof(IEventRepository), typeof(EventRepository))
               .AddScoped(typeof(IMeetingRepository), typeof(MeetingRepository))
               .AddScoped(typeof(IMemberRepository), typeof(MemberRepository))
               .AddScoped(typeof(IMessageRepository), typeof(MessageRepository))
               .AddScoped(typeof(IOportunityRepository), typeof(OportunityRepository))
               .AddScoped(typeof(ITaskRepository),typeof(TaskRepository))
               .AddScoped(typeof(ITeamRepository),typeof(TeamRepository))
               .AddScoped(typeof(IToDoRepository),typeof(ToDoRepository))
               .BuildServiceProvider();
            return iOContainer.GetRequiredService<IMediator>();
        }
    }
}