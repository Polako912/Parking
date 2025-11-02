namespace Parking.Application.Responses;

public record ParkVehicleResponse
{
    public required string VehicleReg { get; init; }
    
    public required int SpaceNumber { get; init; }
    
    public required DateTime TimeIn { get; init; }
}