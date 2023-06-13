using Task2 = Domain.TeamEntities.Task;

namespace Application.Abstraction
{
    public interface ITaskRepository:IRepository<Task2>
    {
        Task UpdateAsync(int id, bool status);
        
    }
}
