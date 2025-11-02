namespace Parking.Application.DTOs;

public record ParkingSpaceDto
{
    public required int Number { get; init; }
    public required bool IsOccupied { get; init; }
}