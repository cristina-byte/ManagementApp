namespace ManagementTool.API.Dto.UserDtos
{
    public class PutPasswordDto
    {
        public string CurentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
