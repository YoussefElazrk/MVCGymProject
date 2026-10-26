using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations
{
    public abstract class GymUserConfiguration<T> : BaseEntityConfiguration<T> where T : GymUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Name)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PhoneNumber)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CK_Email", "Email LIKE '_%@_%._%'");

                Tb.HasCheckConstraint("CK_PhoneNumber", "PhoneNumber LIKE '01[0125]%' AND LEN(PhoneNumber) = 11");
            });
            builder.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(30)
                    .IsRequired();

                address.Property(a => a.City)
                    .HasColumnName("City")
                    .HasMaxLength(30)
                    .IsRequired();

                address.Property(a => a.BuildingNumber)
                    .HasColumnName("BuildingNumber")
                    .IsRequired();
            });
        }
    }
}
