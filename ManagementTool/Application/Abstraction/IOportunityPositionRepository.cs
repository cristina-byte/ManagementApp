using Domain.OportunityEntities;

namespace Application.Abstraction
{
    public interface IOportunityPositionRepository:IRepository<Position>
    {
        public Task DecrementAvailableSpotsAsync(int id);
    }
}
