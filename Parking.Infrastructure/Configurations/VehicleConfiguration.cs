using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Models;

namespace Parking.Infrastructure.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.VehicleReg)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(x => x.VehicleType)
            .IsRequired();
    }
}