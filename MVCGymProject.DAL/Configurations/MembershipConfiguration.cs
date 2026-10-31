using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class MembershipConfiguration : BaseEntityConfiguration<Membership>
{
    public override void Configure(EntityTypeBuilder<Membership> builder)
    {
        base.Configure(builder);

        builder.Property(m => m.CreatedAt)
            .HasColumnName("StartDate");

        builder.HasOne(m => m.Member)
            .WithMany(mem => mem.Memberships)
            .HasForeignKey(m => m.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Plan)
            .WithMany(p => p.Memberships)
            .HasForeignKey(m => m.PlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
