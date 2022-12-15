using Domain.Entities.TeamEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        public TeamsController()
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTeamById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            Console.WriteLine(team.ToString());
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTeam()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult EditTeam()
        {
            return Ok();
        }

    }
}
