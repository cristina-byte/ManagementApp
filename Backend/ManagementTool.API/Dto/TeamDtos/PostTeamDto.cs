using System.ComponentModel.DataAnnotations;

namespace ManagementTool.API.Dto.TeamDtos
{
    public class PostTeamDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AdminId { get; set; }
    }
}
