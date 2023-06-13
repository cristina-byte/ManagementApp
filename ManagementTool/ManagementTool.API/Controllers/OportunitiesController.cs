using Application.Commands.OportunityCommands;
using Application.Queries.OportunityQueries;
using Application.Queries.UserQueries;
using AutoMapper;
using Domain.OportunityEntities;
using ManagementTool.API.Dto.OportunityDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ManagementTool.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OportunitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OportunitiesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]int page)
        {
            var oportunities = await _mediator.Send(new GetOportunitiesPageQuery { Page = page });
            var oportunitiesDto = _mapper.Map<List<OportunityDto>>(oportunities);

            var count = await _mediator.Send(new GetOportunitiesNumberQuery());

            var metaData = new
            {
                Total = count,
                ItemsPerPage = 3
            };

            Response.Headers.Add("x-total", JsonConvert.SerializeObject(metaData));
            return Ok(oportunitiesDto);
        }

        [HttpGet]
        [Route("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var oportunities = await _mediator.Send(new GetAvailableOportunitiesQuery());
            var oportunitiesDto = _mapper.Map<List<OportunityDto>>(oportunities);
            return Ok(oportunitiesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var oportunity = await _mediator.Send(new GetOportunityQuery { Id = id });
            if (oportunity == null)
                return NotFound();
            var oportunityDto = _mapper.Map<OportunityDto>(oportunity);
            return Ok(oportunityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostOportunityDto oportunity)
        {
            var createdOportunity = await _mediator.Send(new CreateOportunityCommand
            {
                ApplicationDeadline = oportunity.ApplicationDeadline,
                Location = oportunity.Location,
                Description = oportunity.Description,
                StartDate = oportunity.StartDate,
                EndDate = oportunity.EndDate,
                Title = oportunity.Title,
                ImageLink=oportunity.ImageLink,
                Positions=_mapper.Map<List<Position>>(oportunity.Positions)
            });
            return CreatedAtAction(nameof(Get), new { Id = createdOportunity.Id }, createdOportunity);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id, PutOportunityDto oportunity)
        {
            await _mediator.Send(new EditOportunityCommand
            {
                Id = id,
                ApplicationDeadline=oportunity.ApplicationDeadline,
                Location=oportunity.Location,
                Description=oportunity.Description,
                StartDate=oportunity.StartDate,
                EndDate=oportunity.EndDate,
                Title=oportunity.Title,
                ImageLink=oportunity.ImageLink,
                Positions=_mapper.Map<List<Position>>(oportunity.Positions)
            });

            return Ok();
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> AddApplicant(int id, OportunityApplicantDto applicant)
        {
            var user = await _mediator.Send(new GetUserQuery { Id = applicant.UserId });
            if (user == null)
                return BadRequest("User was not found");

            var oportunity = await _mediator.Send(new GetOportunityQuery { Id = id });
            if (oportunity == null)
                return BadRequest("Oportunity was not found");

            await _mediator.Send(new AddApplicantCommand { OportunityId = id, UserId = applicant.UserId, PositionId=applicant.CoreTeamPositionId });
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOportunityCommand { Id = id });
            return NoContent();
        }
    }
}
