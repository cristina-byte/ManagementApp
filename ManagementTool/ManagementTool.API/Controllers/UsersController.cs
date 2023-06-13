using Application.Commands.UserCommand;
using Application.Queries.UserQueries;
using Application.Queries.UsersQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ManagementTool.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    //a url (from uniform resource locator) is a unique identifier used to
    //locate a resource on the Internet.

    //parts of a url 
    //1 - scheme or protocol (http or https)
    //2 - subdomain
    //3 - domain name - actual name of the website. It must be unique. You can't register the same domain name twice. 
    //Domain names are case insensitive. 
    //4 - top-level domain (.com or .edu)
    //5 - port
    //6 - path
    //7 - query - question mark tells the browser taht a query is being performed. 
    //8 - parameters
    //9 - fragments . It is preceded by a hash and directs to secondary resources.
    //Often times the fragment will be an id of an id attribute of an HTML element. 

    //https://managementTool.com:443/users?n=cristina&a=23#345

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
