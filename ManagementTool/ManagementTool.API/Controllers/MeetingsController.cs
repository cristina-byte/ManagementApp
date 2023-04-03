using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.MeetingQueries;
using ManagementTool.API.Dto;
using Application.Commands.MeetingCommands;
using Microsoft.AspNetCore.Authorization;

namespace ManagementTool.API.Controllers
{

    [Authorize]
    [Route("api/{id}/[controller]")]
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
        public async Task<IActionResult> Get(int id, [FromQuery]int month, [FromQuery]int year)
        {
            var meetings = await _mediator.Send(new GetMeetingsQuery { UserId = id,Month=month,Year=year });
            var meetingsDto = _mapper.Map<List<MeetingDto>>(meetings);
            return Ok(meetingsDto);
        }

        [HttpGet]
        [Route("{meetingId}")]
        public async Task<IActionResult> GetById(int meetingId)
        {
            var meeting = await _mediator.Send(new GetMeetingQuery { Id = meetingId });
            if (meeting == null)
                return NotFound();
            var meetingDto = _mapper.Map<GetMeetingDto>(meeting); 
            return Ok(meetingDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PostMeetingDto meeting)
        {
           await _mediator.Send(new CreateMeetingCommand
            {
                Title = meeting.Title,
                Address = meeting.Address,
                StartDate = meeting.StartDate,
                EndDate = meeting.EndDate,
                UserId = meeting.OrganizatorId,
                GuestsId=meeting.GuestsId
            }); 

            return Ok();
        }

        [HttpDelete]
        [Route("{meetingId}")]
        public async Task<IActionResult> Cancel(int meetingId)
        {
            await _mediator.Send(new CancelMeetingCommand { Id = meetingId });
            return NoContent();
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
    }
}
