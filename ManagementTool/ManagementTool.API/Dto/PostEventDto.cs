namespace ManagementTool.API.Dto
{
    public class PostEventDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
