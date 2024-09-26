using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Business.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.ToTable("Category");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("newid()")
                .IsRequired();

            builder.Property(c => c.Title)
                      .IsRequired()
                      .HasColumnType("varchar(255)")
                      .HasMaxLength(255);

            builder.Property(c => c.Description)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }

   
}
