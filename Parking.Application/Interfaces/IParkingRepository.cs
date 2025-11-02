using Parking.Domain.Models;

namespace Parking.Application.Interfaces;

public interface IParkingRepository
{
    IQueryable<ParkingSpace> GetParkingSpaces();
    Task ParkVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task<ParkingRegistry> GetParkingRegistryByVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task<ParkingRegistry> ExitVehicleAsync(string vehicleReg, CancellationToken cancellationToken);
}