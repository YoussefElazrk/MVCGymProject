using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class TrainerConfiguration : GymUserConfiguration<Trainer>
{
    public override void Configure(EntityTypeBuilder<Trainer> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Specialty)
               .HasConversion<string>()
               .HasMaxLength(50);

        builder.Property(t => t.CreatedAt)
       .HasColumnName("HireDate");
    }
}
