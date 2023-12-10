using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MagicPost__Data.Entities;



namespace MagicPost__Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
             builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SendName).IsRequired();
            builder.Property(x => x.ReceiveName).IsRequired();
            builder.Property(x => x.SendAddress).IsRequired();
            builder.Property(x => x.ReceiveAddress).IsRequired();
            builder.Property(x => x.ReceivePhoneNumber).IsRequired();
			builder.Property(x => x.Cuoc).IsRequired();
			builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
           

        }
    }
}
