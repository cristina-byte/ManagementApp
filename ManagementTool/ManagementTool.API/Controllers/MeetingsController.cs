using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.MeetingQueries;
using ManagementTool.API.Dto;

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
            Console.WriteLine("id is " + id);
            var meetings = await _mediator.Send(new GetMeetingsQuery { UserId = id });
            var meetingsDto = _mapper.Map<List<MeetingDto>>(meetings);
            return Ok(meetingsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Meeting meeting)
        {
            return Ok();
        }
    }
}
