using Application.Commands.TeamCommands;
using Application.Queries.ChatQueries;
using Application.Queries.TeamQueries;
using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto;
using ManagementTool.API.Dto.TeamDtos;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

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
        public async Task<IActionResult> GetUserTeams([FromQuery]int userId)
        {
            var teams = await _mediator.Send(new GetUserTeamsQuery { UserId = userId });
            var teamsDto = _mapper.Map<List<GetTeamDto>>(teams);
            return Ok(teamsDto);
        }

        [HttpGet]
        [Route("{teamId}/Chat")]
        public async Task<IActionResult> GetTeamChat(int teamId)
        {
            var team = await _mediator.Send(new GetTeamQuery { Id = teamId });
            if (team == null)
                return NotFound();
            var chat = await _mediator.Send(new GetChatQuery { Id = team.Chat.Id});
            var chatDto = _mapper.Map<GetChatDto>(chat);
            return Ok(chatDto);
        }

        [HttpGet]
        [Route("{teamId}/members")]
        public async Task<IActionResult> GetTeamMembers(int teamId)
        {
            var teamMembers = await _mediator.Send(new GetTeamMembersQuery { TeamId = teamId });
            var teamMembersDto = _mapper.Map<List<UserDto>>(teamMembers);
            return Ok(teamMembersDto);
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> GetById(int teamId)
        {
            var team = await _mediator.Send(new GetTeamQuery { Id=teamId});
            if (team == null)
                return NotFound();
            var teamDto = _mapper.Map<GetTeamDto>(team);
            return Ok(teamDto);
        }

        [HttpPut]
        [Route("{teamId}/members")]
        public async Task<IActionResult> AddMembers(int teamId,ICollection<int> usersId)
        {
            await _mediator.Send(new AddMembersCommand { UsersId = usersId, TeamId =teamId });
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody]PostTeamDto team)
        {
           var addedTeam= await _mediator.Send(new CreateTeamCommand{Name = team.Name,AdminId = team.AdminId});
           await _mediator.Send(new AddMembersCommand { TeamId = addedTeam.Id, UsersId = new List<int> { team.AdminId } });

            return Ok(addedTeam);
        }

        [HttpDelete]
        [Route("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            await _mediator.Send(new DeleteTeamCommand { Id = teamId });
            return NoContent();
        }

        [HttpPut]
        [Route("{teamId}")]
        public async Task<IActionResult> Update(int teamId, [FromBody]string name)
        {
            await _mediator.Send(new EditTeamCommand { Id = teamId, Name = name });
            return NoContent();
        }
    }
}
