using Parking.Domain.Enums;

namespace Parking.Application.DTOs;

public record VehicleDto
{
    public required string VehicleReg { get; init; }
    
    public required VehicleType VehicleType { get; init; }
}