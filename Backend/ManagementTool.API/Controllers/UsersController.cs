using Application.Commands.UserCommand;
using Application.Queries.UserQueries;
using Application.Queries.UsersQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> GetUsers([FromQuery] int? page)
        {
            IEnumerable<User> users;
            List<UserDto> usersDto;

            if (page != null)
            {
              users = await _mediator.Send(new GetUsersPageQuery { Page = (int)page });
              usersDto = _mapper.Map<List<UserDto>>(users);
              var count = await _mediator.Send(new GetMembersNumberQuery());
              var metaData = new
                {
                    Total = count,
                    ItemsPerPage = 5
                };

              Response.Headers.Add("x-total", JsonConvert.SerializeObject(metaData));
              return Ok(usersDto);
            }
            users = await _mediator.Send(new GetUsersQuery());
            usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserQuery {Id=id});
            if (user == null)
                return NotFound();
            var userDto = _mapper.Map<GetUserDto>(user);
            return Ok(userDto);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> EditUser(PutUserDto userDto,int id)
        {
            await _mediator.Send(new EditUserCommand { Id = id, ImageLink = userDto.ImageLink });
            return Ok();
        }
    }
}
