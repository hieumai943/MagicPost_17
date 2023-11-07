using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MagicPost__Data.Entities;


namespace MagicPost__Data.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfigs");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Value).IsRequired(true);
            
        }
    }
}
