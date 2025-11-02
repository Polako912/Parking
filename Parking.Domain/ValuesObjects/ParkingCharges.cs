using Parking.Domain.Enums;

namespace Parking.Domain.ValuesObjects;

public sealed record ParkingCharges
{
    private decimal Rate { get; }
    private decimal FiveMinuteRate { get; }
    
    private ParkingCharges(decimal rate, decimal fiveMinuteRate)
    {
        Rate = rate;
        FiveMinuteRate = fiveMinuteRate;
    }

    private static ParkingCharges CreateCharge(VehicleType vehicleType)
        => vehicleType switch
        {
            VehicleType.SmallCar => new ParkingCharges(0.10m, 1m),
            VehicleType.MediumCar => new ParkingCharges(0.20m, 1m),
            VehicleType.LargeCar => new ParkingCharges(0.40m, 1m),
            _ => throw new ArgumentOutOfRangeException(nameof(vehicleType), vehicleType, "Unknown vehicle type")
        };

    public static double CalculateParkingCharge(VehicleType vehicleType, int minutesParked)
    {
        var chargeData = CreateCharge(vehicleType);
        return (double)(minutesParked * chargeData.Rate + (Math.Floor((decimal)(minutesParked / 5)) * chargeData.FiveMinuteRate));
    }
}