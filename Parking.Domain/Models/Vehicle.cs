using Parking.Domain.Abstractions;
using Parking.Domain.Enums;

namespace Parking.Domain.Models;

public class Vehicle : Entity
{
#pragma warning disable CS8618
    private Vehicle()
    {
    }
#pragma warning restore CS8618

    private Vehicle(string vehicleReg, VehicleType vehicleType)    
    {
        VehicleReg = vehicleReg;
        VehicleType = vehicleType;
    }
    
    public string VehicleReg { get; set; }
    
    public VehicleType VehicleType { get; set; }
    
    public ICollection<ParkingRegistry> ParkingRegistry { get;  set; }
    
    public static Vehicle Create(string vehicleReg, VehicleType vehicleType)
        => new Vehicle(vehicleReg, vehicleType);
}