using Parking.Domain.Abstractions;

namespace Parking.Domain.Models;

public class ParkingSpace : Entity
{
    public int Number { get; set; }
    
    public bool IsOccupied { get; set; }
    
    public ParkingRegistry ParkingRegistry { get; set; }

    public void OccupySpace()
    {
        IsOccupied = true;
    }

    public void FreeSpace()
    {
        IsOccupied = false;
    }
}