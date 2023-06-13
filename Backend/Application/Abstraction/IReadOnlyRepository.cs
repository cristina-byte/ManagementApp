namespace Application.Abstraction
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
