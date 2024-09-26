using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasColumnType("varchar")
                .HasMaxLength(512);

            builder.Property(p => p.Enabled)
                .HasDefaultValue(true);
        }
    }
}
