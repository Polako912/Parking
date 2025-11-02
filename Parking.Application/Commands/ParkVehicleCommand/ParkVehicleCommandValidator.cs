using FluentValidation;
using Parking.Domain.Enums;

namespace Parking.Application.Commands.ParkVehicleCommand;

public sealed class ParkVehicleCommandValidator : AbstractValidator<ParkVehicleCommand>
{
    public ParkVehicleCommandValidator()
    {
        RuleFor(x => x.VehicleReg)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(10);
        
        RuleFor(x => x.VehicleType)
            .Must(IsValidVehicleType);
    }
    
    private static bool IsValidVehicleType(int vehicleType)
        => Enum.IsDefined(typeof(VehicleType), vehicleType); 
}