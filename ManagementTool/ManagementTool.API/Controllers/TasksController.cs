using Application.Commands.TeamCommands;
using Application.Queries.TeamQueries;
using AutoMapper;
using Domain.Entities.TeamEntities;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task2 = Domain.Entities.TeamEntities.Task;

namespace ManagementTool.API.Controllers
{
    [Route("api/teams/{id}/[controller]")]
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
        public async Task<IActionResult> GetToDoLists(int id)
        {
            var tasks = await _mediator.Send(new GetTasksQuery { TeamId = id });
            var tD = _mapper.Map<List<ToDoListDto>>(tasks);
            return Ok(tD);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(int id, ToDo toDo)
        {
            var tD = await _mediator.Send(new CreateToDoListCommand { TeamId = id, Name = toDo.Name });
            return Ok(tD);
        }

        [HttpPost]
        [Route("{toDoId}")]
        public async Task<IActionResult> AddTask(int toDoId, Task2 task)
        {
            var t = await _mediator.Send(new CreateTaskCommand
            {
                Status = "assigned",
                ToDoId = toDoId,
                Title = task.Title
            });
            return Ok(t);
        }
    }
}
