using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations
{
    internal class TrainerConfiguration : GymUserConfiguration<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Speciality)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(50);

        }
    }
}
