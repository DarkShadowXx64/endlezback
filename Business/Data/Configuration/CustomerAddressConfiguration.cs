using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            

            builder.HasKey(ca => ca.Id);

            builder.Property(c => c.Id)
                   .HasDefaultValueSql("newid()")
                   .IsRequired();
            

            // Configuración de la relación con User
            builder.HasOne(ca => ca.User)
                .WithMany(u => u.CustomerAddresses) // Asegúrate de que la propiedad de navegación en User se llama CustomerAddresses
                .HasForeignKey(ca => ca.UserId) // Establece el UserId como clave foránea
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
