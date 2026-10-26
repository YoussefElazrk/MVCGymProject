using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Configurations;
using MVCGymProject.Models;

namespace MVCGymProject.Configurations
{
    public class PlanConfiguration : BaseEntityConfiguration<Plan>
    {
        public override void Configure(EntityTypeBuilder<Plan> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                          .HasColumnType("varchar")
                          .HasMaxLength(50)
                          .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(10, 2);

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
            });
        }
    }
}
