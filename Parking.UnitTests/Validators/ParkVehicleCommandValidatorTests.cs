using FluentAssertions;
using Parking.Application.Commands.ParkVehicleCommand;
using Parking.Domain.Enums;

namespace Parking.Tests.Validators;

public class ParkVehicleCommandValidatorTests
{
    private readonly ParkVehicleCommandValidator _validator = new();

    [Theory]
    [InlineData("AB123", (int)VehicleType.SmallCar)]
    [InlineData("CAR1111", (int)VehicleType.MediumCar)]
    [InlineData("TESTTEST", (int)VehicleType.LargeCar)]
    public void Validation_ShouldPass_WhenValidInputs(string reg, int vehicleType)
    {
        var command = ParkVehicleCommand.Create(reg, vehicleType);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();

    }

    [Theory]
    [InlineData("", (int)VehicleType.SmallCar)]
    [InlineData("A", (int)VehicleType.SmallCar)]
    [InlineData("ABCD", (int)VehicleType.MediumCar)] // too short (<5)
    [InlineData("ABCDEFGHIJKLMNOP", (int)VehicleType.LargeCar)] // too long (>10)
    public void Validation_ShouldFail_WhenRegistrationInvalid(string reg, int vehicleType)
    {
        var command = ParkVehicleCommand.Create(reg, vehicleType);
        
        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(ParkVehicleCommand.VehicleReg));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(99)]
    [InlineData(-1)]
    public void Validation_ShouldFail_WhenVehicleTypeInvalid(int invalidType)
    {
        var command = ParkVehicleCommand.Create("ABC123", invalidType);
        
        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(ParkVehicleCommand.VehicleType));
    }

    [Fact]
    public void Validation_ShouldPass_WhenVehicleTypeIsEnumValue()
    {
        var command = ParkVehicleCommand.Create("REG1234", (int)VehicleType.MediumCar);
        
        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}