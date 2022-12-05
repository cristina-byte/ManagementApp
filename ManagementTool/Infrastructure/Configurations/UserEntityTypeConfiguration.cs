
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //one-to-oane relationship
            //each user has a unique calendar object
            builder.HasOne<Calendar>(u => u.Calendar)
                .WithOne(c => c.Member)
                .HasForeignKey<Calendar>(c => c.MemberId);
        }
    }
}
