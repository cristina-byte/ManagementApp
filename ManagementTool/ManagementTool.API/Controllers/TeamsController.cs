using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;
using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TeamsController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]int page)
        {
            Console.WriteLine("Hello from controller");
           var ts = await _mediator.Send(new GetTeamsPageQuery{Page = page});
            var teams = _mapper.Map<List<TeamDto>>(ts);
            return Ok(teams);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var t = await _mediator.Send(new GetTeamQuery{Id = id});
            var team = _mapper.Map<TeamDto>(t);
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody]PostTeamDto team)
        {
           var addedTeam= await _mediator.Send(new CreateTeamCommand{Name = team.Name,AdminId = team.AdminId});
            Console.WriteLine(addedTeam);
            return CreatedAtAction(nameof(GetTeamById), new {Id = addedTeam.Id }, addedTeam); 
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _mediator.Send(new DeleteTeamCommand { Id = id });
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]string name)
        {
            await _mediator.Send(new EditTeamCommand { Id = id, Name = name });
            return Ok();
        }
    }
}
