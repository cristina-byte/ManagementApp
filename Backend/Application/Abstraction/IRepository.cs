namespace Application.Abstraction
{
    public interface IRepository<TEntity>
    {
        public Task CreateAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity, int id);
        public Task DeleteAsync(int id);
    }
}
