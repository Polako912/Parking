namespace Parking.Application.DTOs;

public record ParkingRegistryDto
{
    public required Guid VehicleId { get; init; }
    public required Guid ParkingSpaceId { get; init; }
    public required DateTime TimeIn { get; init; }
    public required DateTime TimeOut { get; init; }
    public required VehicleDto Vehicle { get; init; }
    public required ParkingSpaceDto ParkingSpace { get; init; }
}