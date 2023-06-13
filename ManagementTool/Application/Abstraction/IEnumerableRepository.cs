namespace Application.Abstraction
{
   public interface IEnumerableRepository<TEntity>
    {
        Task<int> GetNumberAsync();
        Task<IEnumerable<TEntity>> GetPageAsync(int page);
    }
}
