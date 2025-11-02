using FluentAssertions;
using Parking.Domain.Enums;
using Parking.Domain.ValuesObjects;

namespace Parking.Tests.ValueObjects;

public class ParkingChargesTests
{
    [Theory]
    [InlineData(VehicleType.SmallCar, 1, 0.10)]
    [InlineData(VehicleType.SmallCar, 5, 1.50)]
    [InlineData(VehicleType.SmallCar, 10, 3.00)]
    [InlineData(VehicleType.MediumCar, 1, 0.20)]
    [InlineData(VehicleType.MediumCar, 5, 2.00)]
    [InlineData(VehicleType.MediumCar, 6, 2.20)]
    [InlineData(VehicleType.LargeCar, 1, 0.40)]
    [InlineData(VehicleType.LargeCar, 5, 3.00)]
    [InlineData(VehicleType.LargeCar, 9, 4.60)] 
    public void CalculateParkingCharge_ShouldReturnExpectedValue(
        VehicleType vehicleType, int minutes, double expected)
    {
        var result = ParkingCharges.CalculateParkingCharge(vehicleType, minutes);

        result.Should().Be(expected);
    }

    [Fact]
    public void CalculateParkingCharge_ShouldThrow_WhenInvalidVehicleType()
    {
        const VehicleType invalidVehicleType = (VehicleType)999;

        Assert.Throws<ArgumentOutOfRangeException>(() => ParkingCharges.CalculateParkingCharge(invalidVehicleType, 10));
    }

    [Fact]
    public void CalculateParkingCharge_ShouldReturnZero_WhenZeroMinutes()
    {
        const VehicleType vehicleType = VehicleType.SmallCar;

        var result = ParkingCharges.CalculateParkingCharge(vehicleType, 0);

        result.Should().Be(0);
    }

    [Theory]
    [InlineData(4, 0.40)]
    [InlineData(5, 1.50)]
    [InlineData(9, 1.90)]
    [InlineData(10, 3.00)]
    public void CalculateParkingCharge_ShouldCalculateCorrectly_WhenFiveMinuteChunks(int minutes, double expected)
    {
        const VehicleType vehicleType = VehicleType.SmallCar;

        var result = ParkingCharges.CalculateParkingCharge(vehicleType, minutes);

        result.Should().Be(expected);
    }
}