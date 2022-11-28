namespace Domain.Entities.OportunityEntities
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int LeftSits { get; set; }

        public Position(int id, string name, int leftSits)
        {
            Id = id;
            Name = name;
            LeftSits = leftSits;
        }
    }
}
