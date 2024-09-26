//using Core.Entities;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;


//namespace Business.Data.Configuration
//{
//    public class ProductCommentsConfiguration : IEntityTypeConfiguration<ProductComments>
//    {
//        public void Configure(EntityTypeBuilder<ProductComments> builder)
//        {
//            builder.ToTable("ProductComments");

//            builder.HasKey(pc => pc.Id);

//            builder.Property(pc => pc.Id)
//                .HasDefaultValueSql("newid()");

//            builder.Property(pc => pc.Comment)
//                .HasColumnType("varchar")
//                .IsRequired();

//            builder.Property(pc => pc.Rating)
//                .IsRequired();

//            builder.Property(pc => pc.CreateDate)
//                .IsRequired()
//                .HasDefaultValueSql("dateadd(hour,(-5),getutcdate())");

//            builder.HasOne(pc => pc.Product)
//                .WithMany()
//                .HasForeignKey(pc => pc.ProductId)
//                .OnDelete(DeleteBehavior.Restrict);
//        }
//    }
//}
