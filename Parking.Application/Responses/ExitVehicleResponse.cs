namespace Parking.Application.Responses;

public record ExitVehicleResponse
{
    public required string VehicleReg { get; init; }
    
    public required double VehicleCharge { get; init; }
    
    public required DateTime TimeIn { get; init; }
    
    public required DateTime TimeOut { get; init; }
}