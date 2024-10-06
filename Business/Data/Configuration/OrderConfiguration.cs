using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            

            builder.HasKey(o => o.Id);
            builder.Property(c => c.Id)
                 .HasDefaultValueSql("newid()")
                 .IsRequired();


            builder.Property(o => o.UserId)
                .IsRequired(); // El Id del cliente es requerido

          

            builder.Property(o => o.Total).HasColumnType("decimal(18,2)"); // El total se mapea automáticamente

            builder.Property(o => o.OrderTypeId); // El tipo de orden se mapea automáticamente

            builder.Property(o => o.OrderStatusId); // El estado de la orden se mapea automáticamente

            builder.Property(o => o.CreatedDate)
                .IsRequired(); // Fecha de creación de la orden es requerida

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.OrderType)
                .WithMany()
                .HasForeignKey(o => o.OrderTypeId);

            builder.HasOne(o => o.OrderStatus)
                .WithMany()
                .HasForeignKey(o => o.OrderStatusId);

        }
    }
}
