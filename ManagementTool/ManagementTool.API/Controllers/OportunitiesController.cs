using Application.Commands.OportunityCommands;
using Application.Queries.OportunityQueries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.OportunityEntities;
using ManagementTool.API.Dto.OportunityDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

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
            return Ok(oportunitiesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var oportunity = await _mediator.Send(new GetOportunityQuery { Id = id });
            var oportunityDto = _mapper.Map<OportunityDto>(oportunity);
            return Ok(oportunityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Oportunity oportunity)
        {
            var createdOportunity = await _mediator.Send(new CreateOportunityCommand
            {
                ApplicationDeadline = oportunity.ApplicationDeadline,
                Location = oportunity.Location,
                Description = oportunity.Description,
                StartDate = oportunity.StartDate,
                EndDate = oportunity.EndDate,
                Title = oportunity.Title
            });
            return CreatedAtAction(nameof(Get), new { Id = createdOportunity.Id }, createdOportunity);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id, Oportunity oportunity)
        {
            await _mediator.Send(new EditOportunityCommand
            {
                Id = id,
                ApplicationDeadline=oportunity.ApplicationDeadline,
                Location=oportunity.Location,
                Description=oportunity.Description,
                StartDate=oportunity.StartDate,
                EndDate=oportunity.EndDate,
                Title=oportunity.Title
            });
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOportunityCommand { Id = id });
            return Ok();
        }
    }
}
