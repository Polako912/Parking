using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Domain.Models;

namespace Parking.Infrastructure.Configurations;

public class ParkingSpaceConfiguration : IEntityTypeConfiguration<ParkingSpace>
{
    public void Configure(EntityTypeBuilder<ParkingSpace> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.IsOccupied).IsRequired();
    }
}