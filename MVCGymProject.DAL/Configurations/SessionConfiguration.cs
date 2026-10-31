using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public class SessionConfiguration : BaseEntityConfiguration<Session>
{
    override public void Configure(EntityTypeBuilder<Session> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Description)
               .IsRequired()
               .HasMaxLength(200);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Session_Capacity", "Capacity BETWEEN 1 AND 25");
            t.HasCheckConstraint("CK_Session_Dates", "EndDate > StartDate");

        });
        builder.HasOne(s => s.Category)
       .WithMany(c => c.Sessions)
       .HasForeignKey(s => s.CategoryId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Trainer)
       .WithMany(t => t.Sessions)
       .HasForeignKey(s => s.TrainerId)
       .OnDelete(DeleteBehavior.Restrict);


    }
}
