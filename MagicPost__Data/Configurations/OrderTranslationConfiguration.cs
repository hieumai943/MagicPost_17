using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MagicPost__Data.Entities;

namespace MagicPost__Data.Configurations
{
    public class OrderTranslationConfiguration : IEntityTypeConfiguration<OrderTranslation>
    {
        public void Configure(EntityTypeBuilder<OrderTranslation> builder)
        {
            builder.ToTable("OrderTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Details).HasMaxLength(500);


            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.LanguageId);

        }
    }
}
