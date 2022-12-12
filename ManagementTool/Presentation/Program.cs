using Application.Abstraction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repositories;
using Application.Commands.EventCommands;
using Infrastructure;
using Task = System.Threading.Tasks.Task;
using Application.Commands.TeamCommands;
using Application.Commands.UserCommand;
using Application.Commands.OportunityCommands;

namespace Presentation
{
    public class Program
    {
        private static IMediator _mediator;

        static  void Main(string[] args)
        {
            //get the mediator service
            _mediator = Init();
            Task.Delay(90000).Wait();
        }

        public async static Task PopulateDatabase()
        {
            await PopulateDatabaseWithToDo();
            await PopulateDatabaseWithTasks();
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
               .AddScoped(typeof(ITeamRepository),typeof(TeamRepository))
               .AddScoped(typeof(IToDoRepository),typeof(ToDoRepository))
               .AddScoped(typeof(ITaskRepository), typeof(TaskRepository))
               .AddScoped(typeof(ICalendarRepository), typeof(CalendarRepository))
               .AddScoped(typeof(IChatRepository), typeof(ChatRepository))
               .AddScoped(typeof(IMessageRepository), typeof(MessageRepository))
               .BuildServiceProvider();
            return iOContainer.GetRequiredService<IMediator>();
        }

        public async static Task PopulateDatabaseWithUsers()
        {
            //addUsers
           await _mediator.Send(new CreateUserCommand
            {
                Name = "Cristina Siscanu",
                Password = "user45",
                Email = "cristinasiscanu30@gmail.com",
                Phone = "0749202818",
                Cnp = "1234678909876",
                BirthDay = new DateTime(2000, 4, 15)
            });

           await _mediator.Send(new CreateUserCommand
            {
                Name = "Viorica Siscanu",
                Password = "parola",
                Email = "viorica@gmail.com",
                Phone = "0978564590",
                Cnp = "9089909856432",
                BirthDay = new DateTime(1995, 3, 2)
            });

            await _mediator.Send(new CreateUserCommand
            {
                Name = "Ana Nimerenco",
                Password = "ana56",
                Email = "ananimerenco@gmail.com",
                Phone = "0754323456",
                Cnp = "1090097543267",
                BirthDay = new DateTime(1994, 1, 22)
            });

           await _mediator.Send(new CreateUserCommand
            {
                Name = "Ion Tutu",
                Password = "tutu",
                Email = "ion@gmail.com",
                Phone = "0754321678",
                Cnp = "9087543234567",
                BirthDay = new DateTime(1990, 10, 6)
            });

           await _mediator.Send(new CreateUserCommand
            {
                Name = "Constantin Vleju",
                Password = "vlejuconstantin",
                Email = "vleju@gmail.com",
                Phone = "0876543267",
                Cnp = "9086543278900",
                BirthDay = new DateTime(1992, 8, 5)
            });
        }
        public async static Task PopulateDatabaseWithTeams()
        {
           await _mediator.Send(new CreateTeamCommand
            {
                Name = "Christmas Charity",
                AdminId = 1
            });

           await _mediator.Send(new CreateTeamCommand
            {
                Name = "Recruitments",
                AdminId = 2
            });

           await _mediator.Send(new CreateTeamCommand
            {
                Name = "Planting Tree",
                AdminId = 2
            });

            await _mediator.Send(new CreateTeamCommand
            {
                Name = "HR Department",
                AdminId = 4
            });

            await _mediator.Send(new CreateTeamCommand
            {
                Name = "Secret Santa",
                AdminId = 1
            });
        }
        public async static Task PopulateDatabaseWithToDo()
        {

           await _mediator.Send(new CreateToDoListCommand
            {
                TeamId = 1,
                Name="Food"
            });

           await _mediator.Send(new CreateToDoListCommand
            {
                TeamId = 1,
                Name = "Fundraising"
            });

           await _mediator.Send(new CreateToDoListCommand
            {
                TeamId = 3,
                Name = "Fundraising"
            });

            await _mediator.Send(new CreateToDoListCommand
            {
                TeamId = 3,
                Name = "Done"
            });

            await _mediator.Send(new CreateToDoListCommand
            {
                TeamId = 2,
                Name = "Interviews"
            });
        }
        public async static Task PopulateDatabaseWithTasks()
        {
            await _mediator.Send(new CreateTaskCommand
            {
                Title = "Make a list of needed products",
                Status = "Unfinished",
                ToDoId = 1
            });

            await _mediator.Send(new CreateTaskCommand
            {
                Title = "Make a budget",
                Status = "Unfinished",
                ToDoId = 1
            });

            await _mediator.Send(new CreateTaskCommand
            {
                Title = "Go shopping",
                Status = "Unfinished",
                ToDoId = 1
            });

            await _mediator.Send(new CreateTaskCommand
            {
                Title = "Cook food",
                Status = "Unfinished",
                ToDoId = 1
            });

            await _mediator.Send(new CreateTaskCommand
            {
                Title = "Make a scheduale",
                Status = "Unfinished",
                ToDoId = 5
            });
        }
        public async static Task PopulateDatabaseWithEvents()
        {
            await _mediator.Send(new CreateEventCommand
            {
                Name = "Christmas Charity",
                Address = "FC Ripensia",
                Description = "Lets help children",
                StartDate = new DateTime(2022, 12, 12),
                EndDate = new DateTime(2022, 12, 14)
            });

            await _mediator.Send(new CreateEventCommand
            {
                Name = "Christams Party",
                Address = "Mihai Eminescu, nr.6",
                Description = "Lets celebrate Christmas together",
                StartDate = new DateTime(2022, 12, 23,15,30,0),
                EndDate = new DateTime(2022, 12, 23, 22, 00, 0)
            });

            await _mediator.Send(new CreateEventCommand
            {
                Name = "Trees Plantation",
                Address = "Park next to Cathedral",
                Description = "Let's help the nature to recover",
                StartDate = new DateTime(2023, 4, 15, 10, 00, 0),
                EndDate = new DateTime(2023, 4, 15, 16, 00, 0)
            });

            await _mediator.Send(new CreateEventCommand
            {
                Name = "Garbage Collection",
                Address = "Bulevardul Eroilor de la Tisa",
                Description = "We will collect the plastic garbage from the street",
                StartDate = new DateTime(2023, 5, 10, 9, 00, 0),
                EndDate = new DateTime(2023, 5, 15, 15, 00, 0)
            });

            await _mediator.Send(new CreateEventCommand
            {
                Name = "Training for children",
                Address = "Burebista 34",
                Description = "We will teach them how to crochet",
                StartDate = new DateTime(2023, 2, 24, 12, 00, 0),
                EndDate = new DateTime(2023, 2, 24, 15, 00, 0)
            });
        }
        public async static Task PopulateDatabaseWithOportunities()
        {
            await _mediator.Send(new CreateOportunityCommand
            {
                Title="Christmas Charity for children",
                Description="We need volunteers to send gifts to children",
                StartDate=new DateTime(2023,2,12),
                EndDate = new DateTime(2023, 3, 14),
                Location="Timisoara"
            });

            await _mediator.Send(new CreateOportunityCommand
            {
                Title = "Trees Plantation",
                Description = "We need volunteers to organize the event",
                StartDate = new DateTime(2023, 3, 2),
                EndDate = new DateTime(2023, 3, 10),
                Location = "Timisoara"
            });

            await _mediator.Send(new CreateOportunityCommand
            {
                Title = "Cooking for People",
                Description = "We need volunteers to help with cooking for homeless",
                StartDate = new DateTime(2023, 3, 4,10,0,0),
                EndDate = new DateTime(2023, 3, 4,15,0,0),
                Location = "Timisoara"
            });
        }
    }
}