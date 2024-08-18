using Finazzy.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finazzy.Infrastructure.Configurations.Users;

internal sealed class UserRegistrationConfiguration : IEntityTypeConfiguration<UserRegistration>
{
    public void Configure(EntityTypeBuilder<UserRegistration> builder)
    {
        builder.ToTable("Users", "user");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Username).HasMaxLength(120).IsRequired();

        builder.Property(user => user.Password).HasMaxLength(120);

        builder.Property(user => user.RegisteredOn).IsRequired();
    }
}
