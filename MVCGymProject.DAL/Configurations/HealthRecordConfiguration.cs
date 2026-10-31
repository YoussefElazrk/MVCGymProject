using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class HealthRecordConfiguration : BaseEntityConfiguration<HealthRecord>
{
    override public void Configure(EntityTypeBuilder<HealthRecord> builder)
    {
        base.Configure(builder);

        builder.Property(hr => hr.Height)
              .HasPrecision(5, 2);

        builder.Property(hr => hr.Weight)
               .HasPrecision(5, 2);

        builder.Property(hr => hr.BloodType)
               .IsRequired()
               .HasMaxLength(3);

        builder.Property(hr => hr.Note)
               .HasMaxLength(500);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_HealthRecord_BloodType",
                "BloodType IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')");
        });

        builder.HasOne(hr => hr.Member)
            .WithOne(m => m.HealthRecord)
            .HasForeignKey<HealthRecord>(hr => hr.Id)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
