using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

internal class MemberConfiguration : GymUserConfiguration<Member>
{
    public override void Configure(EntityTypeBuilder<Member> builder)
    {
        base.Configure(builder);

        builder.Property(m => m.PhotoUrl)
               .HasMaxLength(200);
    }
}
