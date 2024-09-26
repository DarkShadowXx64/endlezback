using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Business.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            

            builder.HasKey(u => u.Id);

            builder.Property(pi => pi.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(u => u.Name)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnType("varchar"); // Nombre del usuario es requerido, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Apellido del usuario es requerido, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Correo electrónico del usuario es requerido, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar"); // Contraseña del usuario es requerida, tiene una longitud máxima de 255 caracteres y se mapea como varchar

            builder.Property(u => u.EmailConfirmed); // Confirmación de correo electrónico se mapea automáticamente

            builder.Property(u => u.Enabled); // Habilitado/deshabilitado se mapea automáticamente

            builder.Property(u => u.IsDeleted); // Indicador de eliminación se mapea automáticamente

            builder.Property(u => u.ProfileId); // Id del perfil se mapea automáticamente

            builder.HasOne(u => u.Profile)
                .WithMany()
                .HasForeignKey(u => u.ProfileId); // Relación con el perfil del usuario

            builder.Property(u => u.CreatedDate)
                .IsRequired(); // Fecha de creación del usuario es requerida

            builder.Property(u => u.ChangedDate)
                .IsRequired(); // Fecha de modificación del usuario es requerida

            builder.Property(u => u.DeletedDate);
        }
    }
}
