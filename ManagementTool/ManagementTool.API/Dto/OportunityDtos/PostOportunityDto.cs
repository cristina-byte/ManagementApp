namespace ManagementTool.API.Dto.OportunityDtos
{
    public class PostOportunityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<PostPositionDto> Positions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string ImageLink { get; set; }
        public DateTime ApplicationDeadline { get; set; }
    }
}
