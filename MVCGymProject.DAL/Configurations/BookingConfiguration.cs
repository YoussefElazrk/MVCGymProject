using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class BookingConfiguration : BaseEntityConfiguration<Booking>
{
    public override void Configure(EntityTypeBuilder<Booking> builder)
    {
        base.Configure(builder);

        builder.Ignore(b => b.Id);
        builder.HasKey(b => new { b.MemberId, b.SessionId });

        builder.Property(b => b.CreatedAt)
            .HasColumnName("BookingDate");

        builder.HasOne(b => b.Member)
       .WithMany(m => m.Bookings)
       .HasForeignKey(b => b.MemberId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Session)
               .WithMany(s => s.Bookings)
               .HasForeignKey(b => b.SessionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
