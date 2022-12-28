namespace ManagementTool.API.Dto.TeamDtos
{
    public class PostTaskDto
    {
        public string Title { get; set; }
        public ICollection<int> UsersId { get; set; }
    }
}
