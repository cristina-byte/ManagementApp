namespace ManagementTool.API.Dto.UserDtos
{
    public class UserSignUpDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }

    }
}
