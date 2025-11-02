using Microsoft.EntityFrameworkCore;
using Parking.Domain.Models;

namespace Parking.Infrastructure;

public class ParkingDbContext(DbContextOptions<ParkingDbContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    
    public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    
    public DbSet<ParkingRegistry> ParkingRegistries { get; set; }
}