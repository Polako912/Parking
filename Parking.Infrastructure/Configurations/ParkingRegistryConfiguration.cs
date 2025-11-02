using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Models;

namespace Parking.Infrastructure.Configurations;

public class ParkingRegistryConfiguration : IEntityTypeConfiguration<ParkingRegistry>
{
    public void Configure(EntityTypeBuilder<ParkingRegistry> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.ParkingRegistry)
            .HasForeignKey(x => x.VehicleId);

        builder.HasOne(x => x.ParkingSpace)
            .WithOne(x => x.ParkingRegistry)
            .HasForeignKey<ParkingRegistry>(x => x.ParkingSpaceId);
    }
}