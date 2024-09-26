using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {

            builder.Property(o => o.Quantity); // La cantidad se mapea automáticamente

            builder.Property(o => o.UnitPrice)
                .HasColumnType("decimal(18,2)");// El precio unitario se mapea automáticamente

            builder.Property(o => o.Discount).HasColumnType("decimal(18,2)");

            builder.HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
