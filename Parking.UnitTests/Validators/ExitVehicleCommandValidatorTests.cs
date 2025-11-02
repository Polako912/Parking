using FluentAssertions;
using Parking.Application.Commands.ExitVehicleCommand;

namespace Parking.Tests.Validators;

public class ExitVehicleCommandValidatorTests
{
    private readonly ExitVehicleCommandValidator _validator = new();

    [Theory]
    [InlineData("ABC123")]
    [InlineData("CAR1111")]
    [InlineData("REG1234")]
    public void Validation_ShouldPass_WhenValidVehicleReg(string reg)
    {
        // Arrange
        var command = ExitVehicleCommand.Create(reg);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("ABCD")]
    [InlineData("ABCDEFGHIJKL")]
    public void Validation_ShouldFail_WhenInvalidVehicleReg(string reg)
    {
        // Arrange
        var command = ExitVehicleCommand.Create(reg);

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(ExitVehicleCommand.VehicleReg));
    }
}