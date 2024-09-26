using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImage");

            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(pi => pi.ImageUrl)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(pi => pi.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("dateadd(hour,(-5),getutcdate())");

            builder.HasOne(pi => pi.Product)
                .WithMany()
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
