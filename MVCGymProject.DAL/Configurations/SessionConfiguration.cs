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
        builder.ToTable(Tb =>
        {
            Tb.HasCheckConstraint("CK_Session_Dates", "EndDate > StartDate");
        });
    }
}
