namespace Domain.Entities.OportunityEntities
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int LeftSits { get; set; }
        public Oportunity Oportunity { get; set; }
        public ICollection<OportunityApplicant> PositionApplicants { get; set; }
    }
}
