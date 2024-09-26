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


            builder.Property(ca => ca.UserId)
           .IsRequired(); // El Id del cliente es requerido

            builder.Property(ca => ca.Street)
                .HasMaxLength(255); // Nombre de la calle tiene una longitud máxima de 255 caracteres

            builder.Property(ca => ca.StreetDetail)
                .HasMaxLength(255); // Detalles adicionales de la calle tiene una longitud máxima de 255 caracteres

            builder.Property(ca => ca.Number)
                .HasMaxLength(50); // Número de la dirección tiene una longitud máxima de 50 caracteres

            builder.Property(ca => ca.Zip)
                .HasMaxLength(20); // Código postal tiene una longitud máxima de 20 caracteres

            builder.Property(ca => ca.Reference)
                .HasMaxLength(255); // Información de referencia adicional para la dirección tiene una longitud máxima de 255 caracteres

            builder.Property(ca => ca.IsPrincipal); // Indicador de dirección principal se mapea automáticamente

            builder.Property(ca => ca.Enabled); // Habilitado/deshabilitado se mapea automáticamente

            builder.Property(ca => ca.IsDeleted); // Indicador de eliminación se mapea automáticamente

            builder.Property(ca => ca.CreatedDate)
                .IsRequired(); // Fecha de creación de la dirección es requerida

            builder.Property(ca => ca.ChangedDate)
                .IsRequired(); // Fecha de modificación de la dirección es requerida

            // Configuración de la relación con User
            builder.HasOne(ca => ca.User)
                .WithMany(u => u.CustomerAddresses) // Asegúrate de que la propiedad de navegación en User se llama CustomerAddresses
                .HasForeignKey(ca => ca.UserId) // Establece el UserId como clave foránea
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
