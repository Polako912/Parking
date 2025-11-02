using MediatR;
using Parking.Application.Responses;

namespace Parking.Application.Commands.ParkVehicleCommand;

public sealed class ParkVehicleCommand : IRequest<ParkVehicleResponse>
{
    public string VehicleReg { get; private set; }
    
    public int VehicleType { get; private set; }

    private ParkVehicleCommand(string vehicleReg, int vehicleType)
    {
        VehicleReg = vehicleReg;
        VehicleType = vehicleType;
    }
    
    public static ParkVehicleCommand Create(string vehicleReg, int vehicleType) 
        => new(vehicleReg, vehicleType);
}