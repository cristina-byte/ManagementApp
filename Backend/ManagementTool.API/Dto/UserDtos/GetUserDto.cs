using Domain.Entities;

namespace ManagementTool.API.Dto.UserDtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public string Cnp { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
