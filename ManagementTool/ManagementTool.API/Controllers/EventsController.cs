using Application.Commands.EventCommands;
using Application.Queries.EventQueries;
using AutoMapper;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EventsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]int page)
        {
            var events = await _mediator.Send(new GetAEventsPageQuery { Page = page });
            return Ok(events);
        }

        [HttpGet]
        [Route("Upcoming")]
        public async Task<IActionResult> GetUpcomingPage([FromQuery] int page)
        {
            var upcomingEvents = await _mediator.Send(new GetUpcomingEventsQuery { Page = page });
            return Ok(upcomingEvents);
        }

        [HttpGet]
        [Route("In Process")]
        public async Task<IActionResult> GetInProcessPage([FromQuery]int page)
        {
            var inProcessEvents = await _mediator.Send(new GetInProcessEventsQuery { Page = page });
            return Ok(inProcessEvents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _mediator.Send(new GetEventQuery { Id = id });
            return Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PostEventDto ev)
        {
            var evt = await _mediator.Send(new CreateEventCommand
            {
                Name = ev.Name,
                Address = ev.Address,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                Description=ev.Description
            });
            return CreatedAtAction(nameof(GetById),new {Id=evt.Id},evt);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id,PostEventDto ev)
        {
            await _mediator.Send(new EditEventCommand
            {
                Id = id,
                Name = ev.Name,
                Address = ev.Address,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                Description = ev.Description
            });

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEventCommand { Id=id});
            return Ok();
        }
    }
}
