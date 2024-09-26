using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            

            builder.HasKey(os => os.Id);

            builder.Property(os => os.Id)
                .HasDefaultValueSql("newid()");


            builder.Property(os => os.Title)
                .IsRequired()
                .HasMaxLength(255); // Título del estado del pedido es requerido y tiene una longitud máxima de 255 caracteres

            builder.Property(os => os.Description)
                .HasMaxLength(255);
        }
    }
}
