using FluentValidation;

namespace Parking.Application.Commands.ExitVehicleCommand;

public sealed class ExitVehicleCommandValidator : AbstractValidator<ExitVehicleCommand>
{
    public ExitVehicleCommandValidator()
    {
        RuleFor(v => v.VehicleReg)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(10);
    }
}