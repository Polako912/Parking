using Microsoft.EntityFrameworkCore;
using Parking.Application.Interfaces;
using Parking.Domain.Models;

namespace Parking.Infrastructure.Repositories;

public class ParkingRepository(ParkingDbContext context) : IParkingRepository
{
    public IQueryable<ParkingSpace> GetParkingSpaces()
        => context.ParkingSpaces.AsQueryable();

    public async Task ParkVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        var parkingSpace = await context.ParkingSpaces.FirstOrDefaultAsync(x=> !x.IsOccupied, cancellationToken) 
                           ?? throw new InvalidOperationException("No available parking spaces.");
        
        parkingSpace.OccupySpace();
        
        context.Vehicles.Add(vehicle);

        var parkingRegistry = new ParkingRegistry
        {
            VehicleId = vehicle.Id,
            ParkingSpaceId = parkingSpace.Id,
            TimeIn = DateTime.Now
        };
        
        context.ParkingRegistries.Add(parkingRegistry);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ParkingRegistry> GetParkingRegistryByVehicleAsync(Vehicle vehicle,
        CancellationToken cancellationToken)
    {
        return await context.ParkingRegistries
            .Include(x=>x.Vehicle)
            .Include(x=>x.ParkingSpace)
            .SingleAsync(x=>x.Vehicle.VehicleReg == vehicle.VehicleReg && x.Vehicle.VehicleType == vehicle.VehicleType, cancellationToken);
    }

    public async Task<ParkingRegistry> ExitVehicleAsync(string vehicleReg, CancellationToken cancellationToken)
    {
        var record = await context.ParkingRegistries
                         .Include(x => x.Vehicle)
                         .Include(x => x.ParkingSpace)
                         .FirstOrDefaultAsync(x => x.Vehicle.VehicleReg == vehicleReg, cancellationToken)
                     ?? throw new InvalidOperationException("Vehicle not found.");

        record.TimeOut = DateTime.Now;

        record.ParkingSpace.FreeSpace();

        await context.SaveChangesAsync(cancellationToken);
        return record;
    }
}