using Application.Queries.UserQueries;
using Application.Queries.UsersQueries;
using AutoMapper;
using Domain.Entities;
using ManagementTool.API.Dto.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementTool.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthController(IMapper mapper, IMediator mediator,UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userManager = userManager;
            _roleManager = roleManager;  
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            var userExists = await _userManager.FindByNameAsync(userSignUpDto.UserName);

            if (userExists!=null)
            {
                return BadRequest("User already exists");
            }

            User user = new User()
            {
                Email = userSignUpDto.Email,
                UserName = userSignUpDto.UserName,
                PhoneNumber = userSignUpDto.PhoneNumber,
                Name = userSignUpDto.Name,
                BirthDay = userSignUpDto.BirthDay,
                ImageLink = "https://media.istockphoto.com/id/1298261537/vector/blank-man-profile-head-icon-placeholder.jpg?s=612x612&w=0&k=20&c=CeT1RVWZzQDay4t54ookMaFsdi7ZHVFg2Y5v7hxigCA="
            };
           
            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);

            if (userCreateResult.Succeeded)
            {
                var u = await _userManager.FindByNameAsync(user.UserName);
                
                    var addRoleToUser = await _userManager.AddToRoleAsync(u, "reader");

                    if (!addRoleToUser.Succeeded)
                        return Problem(addRoleToUser.Errors.First().Description, null, 500);

                    return Ok("User created successfully");
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpDelete]
        [Route("delete-role")]
        public async Task<IActionResult> DeleteRole(UserRoleDto userRole)
        {
            User user = await _userManager.FindByNameAsync(userRole.UserName);
            if (user == null)
                return BadRequest("User was not found");

            var role = await _roleManager.FindByNameAsync(userRole.Role);

            if (role == null)
                return BadRequest("Role was not found");

            var deleteAction = await _userManager.RemoveFromRoleAsync(user, userRole.Role);

            if (!deleteAction.Succeeded)
                return BadRequest("Failed to delete");

            return NoContent();
        }

        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole(UserRoleDto userRole)
        {
            User user = await _userManager.FindByNameAsync(userRole.UserName);

            if (user == null)
               return BadRequest("User not found");

            var role = await _roleManager.FindByNameAsync(userRole.Role);
           if (role == null)
            {
                var addedRole = await _roleManager.CreateAsync(new IdentityRole<int>
                {
                    Name = userRole.Role
                });
            }

            var addedRoleToUser = await _userManager.AddToRoleAsync(user, userRole.Role);

           if (!addedRoleToUser.Succeeded)
              return BadRequest("Fail to add user to role");

            return Ok("User was added to role");
        }


        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            var usersDto = _mapper.Map<List<GetUserRolesDto>>(users);

            foreach(var user in usersDto)
            {
                var u = await _userManager.FindByNameAsync(user.UserName);
                user.Roles = (List<string>)await _userManager.GetRolesAsync(u);
            }

            return Ok(usersDto);
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn(UserSignInDto userSignInDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userSignInDto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userSignInDto.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };

                foreach (var userRole in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                authClaims.Add(new Claim(ClaimTypes.Name, user.Name));

                authClaims.Add(new Claim("id", user.Id.ToString()));
                
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5b1dc4c1-1fa3-4e3d-9f47-04d5a566ba55"));

                var token = new JwtSecurityToken(
                   issuer: "https://localhost:7257",
                   audience: "http://localhost:3000",
                   claims: authClaims,
                   expires: DateTime.Now.AddHours(2),
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
               );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized("Email or password is wrong");
        }
    }
}
