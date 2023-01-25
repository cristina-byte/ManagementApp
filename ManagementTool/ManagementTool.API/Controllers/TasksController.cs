using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;
using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto.TeamDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ManagementTool.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Route("api/Users/{userId}/Teams/{teamId}/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamTasks(int teamId)
        {
            var tasks = await _mediator.Send(new GetTasksQuery { TeamId = teamId });
            var tasksDto = _mapper.Map<List<ToDoListDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(int teamId, [FromBody]string toDoName)
        {
            var toDoList = await _mediator.Send(new CreateToDoListCommand { TeamId = teamId, Name = toDoName });
            //return CreatedAtAction(nameof(GetTeamTasks), new { Id = teamId },toDoList);
            return Ok(toDoList);
        }

        [HttpPost]
        [Route("{toDoId}")]
        public async Task<IActionResult> AddTask(int toDoId, PostTaskDto task)
        {
            var t = await _mediator.Send(new CreateTaskCommand
            {
                Status = "assigned",
                ToDoId = toDoId,
                Title = task.Title
            });
            // return CreatedAtAction(nameof(GetTeamTasks), t);
            return Ok(t);
        }

        [HttpDelete]
        [Route("{toDoId}")]
        public async Task<IActionResult> DeleteTasksList(int toDoId)
        {
            await _mediator.Send(new DeleteTasksListCommand { TasksListId = toDoId });
            return Ok();
        }

        [HttpDelete]
        [Route("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            await _mediator.Send(new DeleteTaskCommand { TaskId = taskId });
            return Ok();
        }
    }
}
