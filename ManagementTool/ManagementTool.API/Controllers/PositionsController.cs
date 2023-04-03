using Application.Queries.OportunityQueries;
using AutoMapper;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    [Route("api/oportunities/{oportunityId}/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PositionsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{positionId}/applicants")]
        public async Task<IActionResult> GetApplicants(int oportunityId, int positionId)
        {
            var users = await _mediator.Send(new GetApplicantsQuery { OportunityId = oportunityId, PositionId = positionId });
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

    }
}
