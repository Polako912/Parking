using Parking.Domain.Models;

namespace Parking.Infrastructure;

public class DataGenerator(ParkingDbContext context)
{
    public void Initialize()
    {
        context.ParkingSpaces.AddRange(GetParkingSpaces());
        context.SaveChanges();
    }

    private IEnumerable<ParkingSpace> GetParkingSpaces()
    {
        return
        [
            new ParkingSpace
            {
                Number = 1,
                IsOccupied = false,
            },
            // new ParkingSpace
            // {
            //     Number = 2,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 3,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 4,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 5,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 6,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 7,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 8,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 9,
            //     IsOccupied = false,
            // },
            // new ParkingSpace
            // {
            //     Number = 10,
            //     IsOccupied = false,
            // }
        ];
    }
}