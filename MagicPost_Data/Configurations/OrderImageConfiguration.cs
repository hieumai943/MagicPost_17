using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MagicPost_Data.Entities;


namespace MagicPost_Data.Configurations
{
    public class OrderImageConfiguration : IEntityTypeConfiguration<OrderImage>
    {
        public void Configure(EntityTypeBuilder<OrderImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);
        }
    }
}
