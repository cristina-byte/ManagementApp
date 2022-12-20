using Application.Queries.UserQueries;
using Application.Queries.UsersQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("page")]
        public async Task<IActionResult> GetAll([FromQuery]int page)
        {
            var users = await _mediator.Send(new GetUsersPageQuery { Page = page });
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _mediator.Send(new GetUserQuery {Id=id});
            var userDto = _mapper.Map<ViewUserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, User user)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
