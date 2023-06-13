using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;
using AutoMapper;
using ManagementTool.API.Dto.TeamDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    
    [Route("api/Teams/{teamId}/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ToDoListsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamToDoLists(int teamId)
        {
            var toDoLists = await _mediator.Send(new GetTasksQuery { TeamId = teamId });
            var toDoListsDto = _mapper.Map<List<ToDoListDto>>(toDoLists);
            return Ok(toDoListsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(int teamId, [FromBody]PostToDoListDto toDoList)
        {
            var addedToDoList = await _mediator.Send(new CreateToDoListCommand { TeamId = teamId, Name = toDoList.Name });
            return Ok();
        }

        [HttpPost]
        [Route("{toDoId}/tasks")]
        public async Task<IActionResult> AddTask(int toDoId, PostTaskDto task)
        {
            var t = await _mediator.Send(new CreateTaskCommand
            {
                Status = "assigned",
                ToDoId = toDoId,
                Title = task.Title
            });
           
            return Ok(t);
        }

        [HttpDelete]
        [Route("{toDoId}/tasks/{taskId}")]

        public async Task<IActionResult> DeleteTask(int taskId)
        {
            await _mediator.Send(new DeleteTaskCommand { TaskId = taskId });
            return NoContent();
        }

        [HttpPut]
        [Route("{toDoId}/tasks/{taskId}")]
        public async Task<IActionResult> ChangeTaskStatus(int taskId, [FromBody]PutTaskDto task)
        {
            await _mediator.Send(new EditTaskStatusCommand { TaskId = taskId, IsDone = task.isDone });
            return Ok();
        }


        [HttpDelete]
        [Route("{toDoId}")]
        public async Task<IActionResult> DeleteTasksList(int toDoId)
        {
            await _mediator.Send(new DeleteTasksListCommand { TasksListId = toDoId });
            return NoContent();
        }

    }
}
