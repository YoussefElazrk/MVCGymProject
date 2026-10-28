using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGymProject.DAL.Models;

namespace MVCGymProject.DAL.Configurations;

public abstract class GymUserConfiguration<T> : BaseEntityConfiguration<T> where T : GymUser
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();

        var entityName = typeof(T).Name;
        builder.ToTable(t =>
        {
            t.HasCheckConstraint($"CK_{entityName}_Email", "Email LIKE '_%@_%._%'");
            t.HasCheckConstraint($"CK_{entityName}_PhoneNumber",
                "PhoneNumber LIKE '01[0125]%' AND LEN(PhoneNumber) = 11 AND PhoneNumber NOT LIKE '%[^0-9]%'");
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
                .HasColumnName("BuildingNumber");
        });
    }
}
