using Parking.Domain.Abstractions;

namespace Parking.Domain.Models;

public class ParkingRegistry : Entity
{
    public Guid VehicleId { get; set; }
    public Guid ParkingSpaceId { get; set; }
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public Vehicle Vehicle { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
}