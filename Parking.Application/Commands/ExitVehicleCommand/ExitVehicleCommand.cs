using MediatR;
using Parking.Application.Responses;

namespace Parking.Application.Commands.ExitVehicleCommand;

public sealed class ExitVehicleCommand : IRequest<ExitVehicleResponse>
{
    public string VehicleReg { get; private set; }
    
    private ExitVehicleCommand(string vehicleReg)
    {
        VehicleReg = vehicleReg;
    }
    
    public static ExitVehicleCommand Create(string vehicleReg) 
        => new(vehicleReg);
}