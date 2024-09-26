using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
         

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Título del producto es requerido, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Descripción del producto tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(p => p.Enable); // Habilitado/deshabilitado se mapea automáticamente

            builder.Property(p => p.IsDeleted); // Indicador de eliminación se mapea automáticamente

            builder.Property(p => p.Sku)
                .HasMaxLength(50)
                .HasColumnType("varchar"); // SKU del producto tiene una longitud máxima de 50 caracteres y se mapea como varchar

            builder.Property(p => p.Codigo)
                .HasMaxLength(50)
                .HasColumnType("varchar"); // Código del producto tiene una longitud máxima de 50 caracteres y se mapea como varchar

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");  // Precio del producto se mapea automáticamente

            builder.Property(p => p.Stock); // Stock del producto se mapea automáticamente

            builder.Property(p => p.CategoryId)
                .IsRequired(); // Id de la categoría es requerido

            builder.Property(p => p.UserCreatedId)
                .IsRequired(); // Id del usuario creador es requerido

            builder.Property(p => p.CreatedDate)
                .IsRequired(); // Fecha de creación del producto es requerida

            builder.Property(p => p.UserChangedId)
                .IsRequired(); // Id del usuario que realizó el último cambio es requerido

            builder.Property(p => p.ChangedDate)
                .IsRequired(); // Fecha del último cambio del producto es requerida

            builder.Property(p => p.UserDeletedId)
                .IsRequired(); // Id del usuario que realizó la eliminación es requerido

            builder.Property(p => p.DeletedDate); // Fecha de eliminación del producto es opcional

            // Definición de relaciones con otras entidades
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            builder.HasOne(p => p.UserCreated)
                .WithMany()
                .HasForeignKey(p => p.UserCreatedId);

            builder.HasOne(p => p.UserChanged)
                .WithMany()
                .HasForeignKey(p => p.UserChangedId);
        }
    }
}
