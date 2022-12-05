using Application.Abstraction;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;
using Domain.Entities.TeamEntities;
using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;
using System.Reflection;
using Infrastructure.Repositories;
using Application.Commands.EventCommands;
using Infrastructure;

namespace Presentation
{
    internal class Program
    {
        private static IMediator _mediator;

        static async Task<int> CreateTeam()
        {
           var teamId=await _mediator.Send(new CreateTeamCommand
            { Admin = new User(1, "Cristina Siscanu"), Id = 89000, Name = "Christmas" });

            return teamId;
        }

        static async Task<Team> GetTeamByName()
        {
            var team = await _mediator.Send(new GetTeamQuery { Id = 34 });
            return team;
        }

        static async Task<Unit> ChangeName()
        {

            var teamId = await _mediator.Send(new EditTeamCommand { Id = 89000, Name = "New Christmas Group" });
            return Unit.Task.Result;
        }

        static void CreateUser()
        {

        }

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

        static  void Main(string[] args)
        {
            //define a container for dependency injection
            var iOContainer = new ServiceCollection()
                .AddMediatR(typeof(CreateEventCommand))
                .AddScoped(typeof(IEventRepository), typeof(EventRepository))
                .AddScoped(typeof(ApplicationContext), typeof(ApplicationContext))
                .AddScoped(typeof(IMeetingRepository), typeof(MeetingRepository))
                .AddScoped(typeof(IMemberRepository), typeof(MemberRepository))
                .AddScoped(typeof(IMessageRepository), typeof(MessageRepository))
                .AddScoped(typeof(IOportunityRepository), typeof(OportunityRepository))
                .BuildServiceProvider();

            //get the mediator service
           _mediator=iOContainer.GetRequiredService<IMediator>();

            CreateEvent();
            

        }
    }
}