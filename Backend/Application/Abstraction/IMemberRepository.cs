using Domain.Entities;

namespace Application.Abstraction
{
    public interface IMemberRepository:IEnumerableRepository<User>,IReadOnlyRepository<User>
    {
        Task UpdateAsync(string photoLink, int id);  
    }
}
