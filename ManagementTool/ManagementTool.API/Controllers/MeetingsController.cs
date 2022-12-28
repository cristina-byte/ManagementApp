using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.MeetingQueries;
using ManagementTool.API.Dto;
using Application.Commands.MeetingCommands;

namespace ManagementTool.API.Controllers
{
    [Route("api/users/{id}/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MeetingsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var meetings = await _mediator.Send(new GetMeetingsQuery { UserId = id });
            var meetingsDto = _mapper.Map<List<MeetingDto>>(meetings);
            return Ok(meetingsDto);
        }

        [HttpGet]
        [Route("{meetingId}")]
        public async Task<IActionResult> GetById(int meetingId)
        {
            var meeting = await _mediator.Send(new GetMeetingQuery { Id = meetingId });
            var meetingDto = _mapper.Map<GetMeetingDto>(meeting); 
            return Ok(meetingDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PostMeetingDto meeting)
        {
            var m = await _mediator.Send(new CreateMeetingCommand
            {
                Title = meeting.Title,
                Address=meeting.Address,
                StartDate=meeting.StartDate,
                EndDate=meeting.EndDate,
                UserId=meeting.OrganizatorId
            });

            return CreatedAtAction(nameof(GetById), new { Id = m.Id }, m);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _mediator.Send(new CancelMeetingCommand { Id = id });
            return Ok();
        }

        [HttpPut]
        [Route("{meetingId}")]
        public async Task<IActionResult> Update([FromBody]PutMeetingDto meeting, int meetingId)
        {
            await _mediator.Send(new EditMeetingCommand
            {
                Id=meetingId,
                Title=meeting.Title,
                Address=meeting.Address,
                StartDate=meeting.StartDate,
                EndDate=meeting.EndDate
            });

            return Ok();
        }

        [HttpPut]
        [Route("{id}/members")]
        public async Task<IActionResult> Invite(int id, ICollection<int> usersId)
        {
            await _mediator.Send(new AddGuestsCommand { MeetingId = id, UsersId = usersId });
            return Ok();
        }
    }
}
