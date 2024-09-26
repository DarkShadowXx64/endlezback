using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<OrderType>
    {
        public void Configure(EntityTypeBuilder<OrderType> builder)
        {
            builder.ToTable("OrderTypes"); // Nombre de la tabla en la base de datos

            builder.HasKey(o => o.Id); // Establece la clave primaria

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd(); // Genera automáticamente valores al agregar nuevas filas

            builder.Property(o => o.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Título del tipo de orden es requerido, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(o => o.Description)
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Descripción del tipo de orden tiene una longitud máxima de 255 caracteres y se mapea como varchar
        }
    }
}
