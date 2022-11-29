using Application.Abstraction;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;
using Domain.Entities.TeamEntities;
using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;

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
            var team = await _mediator.Send(new GetTeamQuery { Name = "Christmas" });
            return team;
        }

        static async Task<Unit> ChangeName()
        {

            var teamId = await _mediator.Send(new EditTeamCommand { Id = 89000, Name = "New Christmas Group" });
            return Unit.Task.Result;
        }

        static  void Main(string[] args)
        {
            //define a container for dependency injection
            var iOContainer = new ServiceCollection()
                .AddMediatR(typeof (IMemberRepository))
                .AddScoped<ITeamRepository, InMemoryTeamRepository>()
                .BuildServiceProvider();

            //get the mediator service
           _mediator=iOContainer.GetRequiredService<IMediator>();

            var teamId=CreateTeam();
            Console.WriteLine(teamId.Result);

            var team = GetTeamByName();
            Console.WriteLine(team.Result.ToString());

        }
    }
}