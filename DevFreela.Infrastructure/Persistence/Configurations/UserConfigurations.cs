using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario").HasKey(s => s.Id);

            builder.HasMany(u => u.Skills).WithOne().HasForeignKey(us => us.IdUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
