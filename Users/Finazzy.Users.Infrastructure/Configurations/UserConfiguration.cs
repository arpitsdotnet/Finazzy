using Finazzy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finazzy.Users.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");
        
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Username).HasMaxLength(120).IsRequired();

        builder.Property(user => user.Password).HasMaxLength(120);

        builder.Property(user => user.RegisteredOn).IsRequired();
    }
}
