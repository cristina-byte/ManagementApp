using Application.Commands.UserCommand;
using Application.Queries.ChatQueries;
using Application.Queries.TeamQueries;
using Application.Queries.UserQueries;
using Application.Queries.UsersQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto;
using ManagementTool.API.Dto.TeamDtos;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
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
        public async Task<IActionResult> GetPage([FromQuery]int page)
        {
            var users = await _mediator.Send(new GetUsersPageQuery { Page = page });
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserQuery {Id=id});
            var userDto = _mapper.Map<GetUserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody]PutUserDto user)
        {
            await _mediator.Send(new EditUserCommand
            {
                Id = id,
                ImageLink = user.ImageLink,
                Phone=user.Phone,
                Name=user.Name
            });

            return Ok();
        }

        [HttpPut]
        [Route("{id}/changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] PutPasswordDto password)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return Ok();
        }
    }
}
