namespace Parking.Application.Requests;

public record ParkVehicleRequest
{
    public required string VehicleReg { get; init; }
    public required int VehicleType { get; init; }
}