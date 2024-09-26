using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Core.Entities;

namespace Business.Data.Configuration
{
    public class ProfilePermissionConfiguration : IEntityTypeConfiguration<ProfilePermission>
    {
        public void Configure(EntityTypeBuilder<ProfilePermission> builder)
        {
            

            builder.HasKey(pp => new { pp.ProfileId, pp.PermissionId, pp.MenuId });

            builder.Property(pp => pp.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("dateadd(hour,(-5),getutcdate())");

            builder.HasOne(pp => pp.Profile)
                .WithMany()
                .HasForeignKey(pp => pp.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pp => pp.Permission)
                .WithMany()
                .HasForeignKey(pp => pp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
