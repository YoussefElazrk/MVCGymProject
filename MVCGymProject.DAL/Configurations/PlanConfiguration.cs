using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class PlanConfiguration : BaseEntityConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.Price)
               .HasPrecision(10, 2);

        builder.HasQueryFilter(p => p.IsActive);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Plan_DurationDays", "DurationDays BETWEEN 1 AND 365");
        });
    }
}