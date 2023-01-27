namespace ManagementTool.API.Dto.UserDtos
{
    public class GetUserRolesDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
