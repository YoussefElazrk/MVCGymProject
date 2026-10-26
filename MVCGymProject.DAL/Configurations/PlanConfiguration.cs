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
                      .HasColumnType("varchar")
                      .HasMaxLength(50)
                      .IsRequired();

        builder.Property(p => p.Description)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(p => p.Price)
            .HasPrecision(10, 2);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
        });
    }
}
