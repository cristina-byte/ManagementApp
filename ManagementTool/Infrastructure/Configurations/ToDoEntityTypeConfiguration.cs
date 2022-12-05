using Domain.Entities.TeamEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = Domain.Entities.TeamEntities.Task;

namespace Infrastructure.Configurations
{
    public class ToDoEntityTypeConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasMany<Task>(td => td.Tasks).WithOne(t => t.ToDo);
                   
        }
    }
}
