using MagicPost__Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPost__Data.Configurations
{
    public class DiemTapKetConfiguration : IEntityTypeConfiguration<DiemTapKet>
    {
        public void Configure(EntityTypeBuilder<DiemTapKet> builder)
        {
            builder.ToTable("DiemTapKets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);
            builder.HasOne(x => x.TruongDiemTapKet)
                  .WithOne()
                  .HasForeignKey<DiemTapKet>(x => x.UserId);

        }
    }
}
